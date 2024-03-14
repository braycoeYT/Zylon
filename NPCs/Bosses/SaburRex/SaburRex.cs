using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Zylon.Projectiles.Bosses.SaburRex;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.NPCs.Bosses.SaburRex
{
	[AutoloadBossHead]
    public class SaburRex : ModNPC
	{
        public override void SetStaticDefaults() {

			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			Main.npcFrameCount[NPC.type] = 6;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
		}
        public override void SetDefaults() {
            NPC.width = 58;
			NPC.height = 64;
			NPC.damage = 130;
			NPC.defense = 110;
			NPC.lifeMax = (int)(350000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit6;
			NPC.DeathSound = SoundID.NPCDeath8;
			NPC.value = Item.buyPrice(3);
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			Music = MusicID.Boss1;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(500000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 260;
			NPC.value = Item.buyPrice(7, 50);
			if (Main.masterMode) {
				NPC.lifeMax = (int)(650000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 390;
            }
        }
        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers) {
            modifiers.SetMaxDamage(9999); //Anticheat + jrpg reference
        }
		float ringTotalRot;
		float ringRotSpeed;
		float prevAttack = -1f;
		float descendVel = 10f;
		bool attackDone = true;
        bool init;
		int attackTimer;
		bool dialogue;
		Vector2 ringPos;
        public override void AI() { //ai0 - current attack | ai1 - next attack | ai2 - current rotation
			NPC.TargetClosest();
			Player target = Main.player[NPC.target];
			ZylonGlobalNPC.saburBoss = NPC.whoAmI;



			if (!init) { //Sets up two floating sword projectiles + white light intro
				attackTimer++; //Intro lasts two seconds

				ringRotSpeed = 0.5f;

				if (attackTimer < 120) {
					NPC.position.Y += descendVel;
					descendVel *= 0.978f; //0.98f og
					for (int i = 0; i < 2; i++) {
						int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.PureWhiteDust>());
						Dust dust = Main.dust[dustIndex];
						float mult = 1f;
						if (Main.rand.NextBool()) mult = -1f;
						dust.velocity.X = Main.rand.NextFloat(3f, 6f)*mult;
						dust.velocity.Y = Main.rand.Next(-50, 51) * 0.02f;
						dust.scale *= (1f-(float)attackTimer/120f) + Main.rand.Next(-30, 31) * 0.01f;
					}
				}
				if (attackTimer == 1) {
					//NPC.direction = 1;
					NPC.Center = target.Center - new Vector2(0, 548); //128 normal
					ringPos = target.Center - new Vector2(0, 160);

					dialogue = !Zylon.hasFoughtSabur; //If first fight since world was loaded, use dialogue
					Zylon.hasFoughtSabur = true;
                }
				
				if (dialogue)
                {
					if (attackTimer == 150) Main.NewText("A challenger?", 65, 87, 94);
					if (attackTimer == 310) Main.NewText("You are not who I am searching for...", 65, 87, 94);
					if (attackTimer == 470) Main.NewText("I shall end your life regardless.", 65, 87, 94);
				}
				
				if (attackTimer == 500 || (attackTimer == 180 && !dialogue)) {
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, Vector2.Zero, ModContent.ProjectileType<SaburRexSwordActive>(), NPC.damage/3, 0f);
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, Vector2.Zero, ModContent.ProjectileType<SaburRexSwordFollow>(), NPC.damage/3, 0f);
					init = true;
				}
				
				UpdateFrame();
				if (!init) return;
			}

			if (attackDone) NewAttack();

			switch (NPC.ai[0]) {
				case 0f:
					InfluxWaver();
					break;
            }

			UpdateFrame();
        }
		private void InfluxWaver() {
			attackTimer++;
			NPC.ai[2] += MathHelper.ToRadians(8);
			//NPC.velocity.X = -0.2f;
			if (attackTimer % 360 > 180) NPC.direction = -1;
			else NPC.direction = 1;
        }
		private void UpdateFrame() {
			int frameCount = 0; //Default - hand down at side

			//Make sure we don't go too far either direction
			if (NPC.ai[2] > MathHelper.TwoPi) NPC.ai[2] -= MathHelper.TwoPi;
			if (NPC.ai[2] < 0) NPC.ai[2] += MathHelper.TwoPi;

			if (NPC.ai[2] >= MathHelper.ToRadians(270) && NPC.ai[2] < MathHelper.ToRadians(325)) frameCount = 1; //Hand top left

			if (NPC.ai[2] >= MathHelper.ToRadians(325) || NPC.ai[2] < MathHelper.ToRadians(30)) frameCount = 2; //Hand straight up

			if (NPC.ai[2] >= MathHelper.ToRadians(30) && NPC.ai[2] < MathHelper.ToRadians(75)) frameCount = 3; //Hand top right

			if (NPC.ai[2] >= MathHelper.ToRadians(75) && NPC.ai[2] < MathHelper.ToRadians(115)) frameCount = 4; //Hand right

			if (NPC.ai[2] >= MathHelper.ToRadians(115) && NPC.ai[2] < MathHelper.ToRadians(180)) frameCount = 5; //Hand down right

			//og 105 -> 115

			NPC.frame.Y = frameCount*64;
			if (!init) NPC.frame.Y = 0; //STOP NOT MATCHING YOU DUMMY

			//NPC direction
			if (Math.Abs(NPC.velocity.X) > 0.05f) {
				if (NPC.velocity.X < 0) NPC.direction = -1;
				else NPC.direction = 1;
            }
			NPC.spriteDirection = NPC.direction;
			ringTotalRot += ringRotSpeed; //Rotate the boss ring.
			//Main.NewText(NPC.direction); //test
        }
		private void NewAttack() {
			prevAttack = NPC.ai[0];
			NPC.ai[0] = NPC.ai[1];
			NPC.ai[1] = 0f;
			attackTimer = 0;
			attackDone = false;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) { //Adapted from Adeneb code
			Texture2D whiteTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Light");
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D borderTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Border");

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY); //For main
			Vector2 ringDrawPos = ringPos - screenPos + new Vector2(0f, NPC.gfxOffY); //Permanent pos for ring (see for loop below)

			//Color color = NPC.GetAlpha(drawColor);
			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			Vector2 whiteOrigin = new Vector2(whiteTexture.Width * 0.5f, whiteTexture.Height * 0.5f);
			Vector2 borderOrigin = new Vector2(borderTexture.Width * 0.5f, borderTexture.Height * 0.5f);

			//Stolen from projectile code so that multiple frames can be drawn
			int frameHeight = texture.Height / 6;
			int spriteSheetOffset = frameHeight * (NPC.frame.Y/64);


			//Tome man please explain why I'm dumb and have to manually set the main texture to be lower positioned but not the light sprite (160 is 2.5 frames)
            spriteBatch.Draw(texture, drawPos+new Vector2(0, 160), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, 0f, drawOrigin, NPC.scale, effects, 0); //Draw main boss


			int ringCount = 30;
			//Slowly transition away as he descends
			if (!init) {
				//Color amount = new Color(255, 255, 255); //255-255*((float)attackTimer/120f)
				spriteBatch.Draw(whiteTexture, drawPos, null, Color.White*(1f-(float)attackTimer/120f), 0f, whiteOrigin, NPC.scale, effects, 0); //Draw light for intro
				if (attackTimer < 180) ringCount = (int)(30*(attackTimer/180f));
			}

			//Draws the border of the boss.
			for (int i = 0; i < ringCount; i++) { //i*(360/ringCount) //old
				Vector2 borderPos = ringDrawPos - new Vector2(0, 750).RotatedBy(MathHelper.ToRadians(i*12+ringTotalRot));

				//Cool transition
				float alphaRing = 1f;
				if (i == ringCount - 1 && !init) alphaRing = (attackTimer % 6 / 6f);

				spriteBatch.Draw(borderTexture, borderPos, null, Main.DiscoColor*alphaRing, 0f, borderOrigin, NPC.scale, SpriteEffects.None, 0);
            }
			//spriteBatch.Draw(eyeTexture, eyePos, null, Color.White, 0f, eyeOrigin, NPC.scale, effects, 0); //Draw laser eye
			return false;
        }
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.SuperHealingPotion;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				//BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.,
				new FlavorTextBestiaryInfoElement("A sword-obsessed godlike wolf from another dimension who is so powerful that he can bend the original uses of his blades to his will.")
			});
		}
    }
}