using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Bags;
using Zylon.Projectiles.Bosses.Scavenger;

namespace Zylon.NPCs.Bosses.Scavenger
{
	[AutoloadBossHead]
    public class MatrixScavenger : ModNPC
	{
        public override void SetStaticDefaults() {
			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			Main.npcFrameCount[NPC.type] = 4;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Venom] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Shroomed>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.ElementalDegeneration>()] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Timestop>()] = true;
		}
        public override void SetDefaults() {
            NPC.width = 130;
			NPC.height = 164;
			NPC.damage = 58;
			NPC.defense = 20;
			NPC.lifeMax = (int)(35000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 13);
			NPC.aiStyle = -1; //14
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			Music = MusicID.Boss3;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(52500*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 97;
			NPC.value = 0;
			if (Main.masterMode) {
				NPC.lifeMax = (int)(70000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 136;
            }
        }
		Player target;
		bool attackDone;
		int attackTimer; //Increments, but resets each phase change.
		int attackMode; //What "phase" each attack is in.
		int attackInt;
		float attackFloat;
		float attackFloat2;
		int attackDir; //Has a random chance to be -1 or 1, for determining attack directions
		int nextAttack = -1;
		float totalAttackTimer;

		int warpTimer;
		float warpFloat;

		float hpLeft;
		bool init;
        public override void AI() { //ai0 = attack | ai1 = frame of animation | ai2 = teleport fixer
			if (!init) {
				NPC.ai[0] = -1f;
				nextAttack = GetRandAttack();
				init = true;
			}
			
			NPC.netUpdate = true;
			NPC.TargetClosest(true);
			ZylonGlobalNPC.scavengerBoss = NPC.whoAmI;
			target = Main.player[NPC.target];

			hpLeft = (float)NPC.life/NPC.lifeMax;

			NPC.frameCounter++;
			if (NPC.frameCounter % 6 == 0)
				NPC.ai[1]++;
			if (NPC.ai[1] > 3f)
				NPC.ai[1] = 0f;
			NPC.frame.Y = (int)NPC.ai[1] * 162;

			if (attackDone) {
				//First attack, always use quarter dash
				if (nextAttack == -1) NPC.ai[0] = GetRandAttack();
				else NPC.ai[0] = nextAttack;

				nextAttack = GetRandAttack();
				//while ((int)NPC.ai[0] == nextAttack) nextAttack = GetRandAttack();

				attackDone = false;
				attackTimer = 0;
				attackMode = 0;
				attackInt = 0;
				attackFloat = 0f;
				attackFloat2 = 0f;
				attackDir = -1;
				if (Main.rand.NextBool(2)) attackDir = 1;


				NPC.ai[0] = 0f;
				nextAttack = 0;

				warpTimer = 0;
				totalAttackTimer = -1;

				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<ScavengerDespawn>(), 0, 0f);
            }

			if (nextAttack == -1) NPC.ai[0] = -1f;

			//Main.NewText((int)NPC.ai[0] + " | " + nextAttack + " | " + attackTimer);
			totalAttackTimer++;

			switch (NPC.ai[0]) {
				case -1:
					IntroAttack();
					break;
				case 0:
					QuarterDash();
					break;
			}
			if (warpTimer > 0) WarpSetup();
		}
		private void IntroAttack() {
			attackTimer++;
			if (attackTimer >= 30) warpTimer++;
			if (attackTimer >= 60) attackDone = true;
		}
		private void QuarterDash() {
			attackTimer++;
			
			if (attackMode == 0) { //wait above player
				NPC.Center = target.Center - new Vector2(0, 360).RotatedBy(warpFloat);
				if (attackTimer > 15) {
					attackMode = 1;
					attackTimer = 0;
				}
			}
			else if (attackMode == 1) { //spin around player
				attackFloat2 += (1f-hpLeft)*0.5f;
				attackInt++;

				NPC.Center = target.Center - new Vector2(0, 360).RotatedBy(warpFloat+MathHelper.ToRadians(attackTimer+attackFloat2)*attackDir);
				if (attackInt > 15+(int)(15*hpLeft) && Main.netMode != NetmodeID.MultiplayerClient) {
					SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
					Vector2 speed = Vector2.Normalize(NPC.Center - target.Center);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*-13f, ModContent.ProjectileType<BinaryBlast4x4>(), NPC.damage/4, 0f);
					attackInt = 0;
				}
				if (attackTimer+attackFloat2 > 90f) {
					attackMode = 2;
					attackTimer = 0;
					attackFloat2 = 0f;
				}
			}
			else if (attackMode == 2) { //dash at player
				if (attackTimer == 1) NPC.velocity = Vector2.Normalize(NPC.Center - target.Center)*(-30f+15f*hpLeft);
				NPC.velocity *= 0.95f + 0.03f*hpLeft;
				attackFloat2 += NPC.velocity.Length();
				if (attackFloat2 > 90f && Main.netMode != NetmodeID.MultiplayerClient) {
					SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Normalize(NPC.Center - target.Center)*-0.05f, ModContent.ProjectileType<BinaryBlast4x4Chase>(), NPC.damage/3, 0f, -1, 1.1f);
					attackFloat2 -= 90f;
				}

				if (attackTimer > 75+75*hpLeft) warpTimer++;
				if (attackTimer > 105+75*hpLeft) attackDone = true;
			}
		}
		private int GetRandAttack() {
			return 0; //Main.rand.Next(2);
		}
		private void WarpSetup() { //Increment warp to start the teleport animation and to determine the location of the spawn.
			if (warpTimer == 1) {
				float atk = nextAttack;
				if (NPC.ai[0] <= 0f) 
					warpFloat = Main.rand.NextFloat(MathHelper.TwoPi);

				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Scavenger.ScavengerSpawn>(), 0, 0f, -1, atk, warpFloat);
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			
			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			var effects = SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width*0.5f, texture.Height*0.1f);

			Vector2 scale = Vector2.One;
			if (warpTimer > 20) {
				scale = new Vector2(1f-((warpTimer-20f)/10f), 1f+((warpTimer-20f)/50f));
			}
			else if (totalAttackTimer < 10) {
				scale = new Vector2(totalAttackTimer/10f, 1.2f-(totalAttackTimer/50f));
			}

			spriteBatch.Draw(texture, drawPos, NPC.frame, Color.White, 0f, drawOrigin, scale, effects, 0);
			return false;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement("???")
			});
		}
    }
}