using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using System.Threading;

namespace Zylon.NPCs.Meteorite
{
	public class MeteorCrawler : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 5;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
        }
        public override void SetDefaults() {
            NPC.width = 58;
			NPC.height = 36;
			NPC.damage = 27;
			NPC.defense = 4;
			NPC.lifeMax = 38;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.DeathSound = SoundID.NPCDeath47;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			NPC.aiStyle = 3;
			NPC.knockBackResist = 1.3f;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.MeteorCrawlerBanner>();
			NPC.noGravity = false;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) {
			NPC.lifeMax = 76;
			NPC.damage = 54;
			NPC.knockBackResist = 1.15f;
			NPC.value = Item.buyPrice(0, 0, 3);
			if (Main.hardMode) {
				NPC.lifeMax = 792;
				NPC.damage = 96;
				NPC.value = Item.buyPrice(0, 0, 4, 50);
            }
			if (NPC.downedPlantBoss) {
				NPC.lifeMax = 901;
				NPC.damage = 112;
				NPC.value = Item.buyPrice(0, 0, 5, 25);
            }
			if (Main.masterMode) {
				NPC.lifeMax = (int)(NPC.lifeMax*1.5f);
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.knockBackResist = 1f;
            }
		}
        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone) {
            for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Meteorite);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 1f + Main.rand.Next(-50, 51) * 0.01f;
			}
			/*if (Main.rand.NextBool(10) && Main.expertMode) {
				ballTime = 200;
			}*/
        }
        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone) {
            for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Meteorite);
				Dust dust = Main.dust[dustIndex];
				dust.scale *= 1f + Main.rand.Next(-50, 51) * 0.01f;
			}
			/*if (Main.rand.NextBool(10) && Main.expertMode) {
				ballTime = 200;
			}*/
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(6, 8));
        }
		bool canReach;
		bool canJump;
        int frameID;
		int groundCounter;
		float prevGravity;
		float frameCounter;
		float distance;
		Player target;

		int Timer;
		int ballTime;

		float maxSpeed = 5f + (1f*Main.expertMode.ToInt());
		const float maxFallSpeed = 10f;
        public override bool PreAI() {
            return false;
        }
        public override void PostAI() { //set AI to fighter, then change everything to newVars in postAI?
			Timer++;
			NPC.TargetClosest();
			target = Main.player[NPC.target];
			canReach = Collision.CanHitLine(NPC.position, NPC.width, NPC.height, target.position, target.width, target.height);
			distance = Vector2.Distance(target.Center, NPC.Center);

			if (ballTime > 0) { //Rolls into a ball, gains defense, and rains fire on the player.
				ballTime--;
				NPC.noGravity = true;
				if (Math.Abs(NPC.velocity.X) > 2f) NPC.velocity.X *= 0.95f;
				NPC.velocity.Y *= 0.95f;
				NPC.frame.Y = 144;
				NPC.defense = NPC.defDefense + 20;

				NPC.rotation += MathHelper.ToRadians(NPC.velocity.X);
				for (int i = 0; i < 2; i++) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity = NPC.velocity;
					dust.scale *= 2f + Main.rand.Next(-50, 51) * 0.01f;
				}

				//Spawn Projectiles
				if (Timer % 12 == 0) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-3f, 3f), 2f), ModContent.ProjectileType<Projectiles.Enemies.MeteoriteFireDrop>(), NPC.damage/4, 0f);
				}

				return;
			}
			NPC.noGravity = false;
			NPC.defense = NPC.defDefense;
			NPC.rotation = 0f;

			//Making sure the enemy doesn't fall too fast.
			if (Math.Abs(NPC.velocity.X) > maxSpeed) NPC.velocity.X *= 0.9f;
			if (NPC.velocity.Y > maxFallSpeed) NPC.velocity.Y = maxFallSpeed;

			//Horizontal Movement
			if (NPC.Center.X < target.Center.X) NPC.velocity.X += 0.2f;
				else NPC.velocity.X -= 0.2f;

			//Current tile it's standing on
			int num9 = 0;
			if (NPC.velocity.X < 0f)
				num9 = -1;
			if (NPC.velocity.X > 0f)
				num9 = 1;
			int num10 = (int)((NPC.position.X + (float)(NPC.width / 2) + (float)((NPC.width / 2 + 1) * num9)) / 16f);
			int num11 = (int)((NPC.position.Y + (float)NPC.height - 1f) / 16f);

			//Half-step fix
			if (Main.tile[num10, num11].IsHalfBlock) NPC.position += new Vector2(8*NPC.direction, -8);
			
			//Jumping
			if (canJump && ((target.Center.Y < NPC.Center.Y-48 && canReach) || Math.Abs(NPC.velocity.X) < 0.1f || NPC.collideX || Vector2.Distance(NPC.Center, target.Center) < 128f)) { // && Main.tile[num10, num11].HasUnacutatedTile && Main.tile[num10, num11].
				NPC.velocity.Y = -8f;
				NPC.velocity.X *= 1.25f;
				canJump = false;

				if (Main.rand.NextBool(5) && Main.expertMode) {
					ballTime = 300;
				}
			}

			//Main.NewText(NPC.velocity.X + ", " + NPC.velocity.Y);//Main.tile[num10, num11].HasUnactuatedTile + " | " + Main.tile[num10, num11].BlockType);

			//Resets canJump
			if (Math.Abs(NPC.velocity.Y) < 0.0001f) groundCounter++;
			else groundCounter = 0;

			if (groundCounter >= 15) canJump = true;
			else canJump = false;

			//Visual controls
			NPC.spriteDirection = NPC.direction;
            frameCounter += (int)Math.Abs(NPC.velocity.X);
			if (frameCounter > 10) {
				frameID++;
				frameCounter = 0;
            }
			NPC.frame.Y = (frameID % 4)*36;
			if (NPC.velocity.X == 0) NPC.frame.Y = 0;
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A crawling, bug-like fragment of a fallen meteorite. Has the ability to roll into a gravity-defying ball in moments of danger.")
			});
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.Meteor.Chance * 0.5f;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsPreHardmode(), ItemID.Meteorite, 50));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Ores.HaxoniteOre>(), 1, 1, 4), new CommonDrop(ModContent.ItemType<Items.Ores.HaxoniteOre>(), 1, 2, 4)));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Pets.PlasticDinoFigurine>(), 2000), new CommonDrop(ModContent.ItemType<Items.Pets.PlasticDinoFigurine>(), 1000)));
		}
    }
}