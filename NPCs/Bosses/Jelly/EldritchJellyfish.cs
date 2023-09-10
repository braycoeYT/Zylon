using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Jelly
{
	[AutoloadBossHead]
	public class EldritchJellyfish : ModNPC
	{
		public override void SetStaticDefaults() {

			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			// DisplayName.SetDefault("Eldritch Jellyfish");
			Main.npcFrameCount[NPC.type] = 7;
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,
					BuffID.Confused,
					BuffID.OnFire,
					BuffID.Chilled,
					BuffID.Frozen,
					BuffID.Burning,
					BuffID.Frostburn,
					BuffID.CursedInferno
				}
			};
		}
        public override void SetDefaults() {
			NPC.width = 200;
			NPC.height = 220;
			NPC.damage = 40;
			NPC.lifeMax = (int)(7500*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.defense = 20;
			NPC.HitSound = SoundID.NPCHit25;
			NPC.DeathSound = SoundID.NPCDeath28;
			NPC.value = 60000;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = -1;
			NPC.noGravity = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.noTileCollide = true;
			NPC.lavaImmune = true;
			Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/JellyTheme");
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)((11500 + ((numPlayers - 1) * 3500))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
            NPC.damage = 80;
			NPC.value = 13750;
			if (Main.masterMode) {
				NPC.lifeMax = (int)((15500 + ((numPlayers - 1) * 4100))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 120;
            }
        }
		public override void HitEffect(NPC.HitInfo hit) {
			for (int i = 0; i < 4; i++) {
				int dustType = ModContent.DustType<Dusts.JellyDust>();
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				dust.noGravity = false;
			}
			if (NPC.life < 0) {
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-1, 1), -4), ModContent.GoreType<Gores.Bosses.Jelly.EldritchEyeGore>());
				for (int i = 0; i < 4; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), -4), ModContent.GoreType<Gores.Bosses.Jelly.EldritchTentacleGore>());
				for (int i = 0; i < 8; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), -4), ModContent.GoreType<Gores.Bosses.Jelly.EldritchHeadGore>());
			}
		}
		/*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
			//if (movement && movementTimer > 14)
			//DrawingHelper.NPCAfterImageEffect(NPC, null);
            return true;
        }*/
		Player target;
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		int dashCount;
		int dashType;
		int attackBoost;
		int rand;
		int attackMode;
		int movementTimer;
		int guessAttack;
		int prevAttack;
		int attackRand;
		int attackMax;
		float attackFloat;
		Vector2 look;
		public override void AI() {
			Timer++;
			NPC.TargetClosest(true);
			target = Main.player[NPC.target];
			if (Main.player[NPC.target].statLife < 1)
			{
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1) {
                flee++;
                NPC.noTileCollide = true;
                NPC.velocity.Y = -10f;
                if (flee >= 450)
                    NPC.active = false;
            }
			if (Timer % 5 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			NPC.frame.Y = animationTimer * 272;

			attackBoost = 0;
			if (NPC.life < NPC.lifeMax * 0.75f) attackBoost = 1;
			if (NPC.life < NPC.lifeMax * 0.5f) attackBoost = 2;
			if (NPC.life < NPC.lifeMax * 0.33f) attackBoost = 3;
			if (NPC.life < NPC.lifeMax * 0.2f) attackBoost = 4;
			if (NPC.life < NPC.lifeMax * 0.08f) attackBoost = 5;
			NPC.damage = NPC.defDamage + (attackBoost * 4);
			if (movement) {
				movementTimer++;
				NPC.localAI[2] = 1f;
							NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) + 1.57f;
							float num263 = 3f;
				dashType = 0;
							if (dashType == 0) num263 = 4f;
							if (dashType == 1) num263 = 1f;
							if (dashType == 2) num263 = 5f;
							num263 += attackBoost / 2;
							if (dashType == 0) NPC.velocity *= 0.991f;
							if (dashType == 1) NPC.velocity *= 0.94f;
							if (dashType == 2) NPC.velocity *= 0.993f;
							if (NPC.velocity.X > -num263 && NPC.velocity.X < num263 && NPC.velocity.Y > -num263 && NPC.velocity.Y < num263)
							{
								if (dashCount == 0)
									dashType = Main.rand.Next(3);
								dashCount++;
								NPC.TargetClosest(true);
								float num264 = 12f;
								if (dashType == 0) num264 = 12f;
								if (dashType == 1) num264 = 20f;
								if (dashType == 2) num264 = 16f;
								num264 += attackBoost / 2;
								Vector2 vector31 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
								float num265 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector31.X;
								float num266 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector31.Y;
								float num267 = (float)Math.Sqrt((double)(num265 * num265 + num266 * num266));
								num267 = num264 / num267;
								num265 *= num267;
								num266 *= num267;
								NPC.velocity.X = num265;
								NPC.velocity.Y = num266;
							}
							if (Main.rand.NextBool())
				{
				int dustType = ModContent.DustType<Dusts.WaterDust>();
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = NPC.velocity.X * -0.5f;
				dust.velocity.Y = NPC.velocity.Y * -0.5f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
							if (Timer % 120 == 0 && Main.expertMode)
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + Main.rand.Next(-40, 41), (int)NPC.Center.Y + Main.rand.Next(-40, 41), ModContent.NPCType<DetonatingBubble>());
			}
			if (dashCount > 5) {
				dashCount = 0;
				movement = false;
				attack = 0;
				attackTimer = 0;
				attackDone = false;
				attackMode = 0;
				movementTimer = 0;
			}
			if (attack == 0 && attackDone == false) {
				if (attackMode == 0) {
					NPC.velocity /= 2;
					NPC.alpha += 5;
					if (NPC.alpha > 200)
						NPC.friendly = true;
					if (NPC.alpha > 254)
						attackMode = 1;
				}
				else if (attackMode == 1) {
					NPC.velocity = new Vector2();
					Vector2 newPos;
					rand = Main.rand.Next(2);
					if (rand == 0) rand = -1;
					newPos.X = rand*Main.rand.Next(250, 501);
					rand = Main.rand.Next(2);
					if (rand == 0) rand = -1;
					newPos.Y = rand*Main.rand.Next(250, 501);
					NPC.position = target.Center + newPos;
					attackMode = 2;
					attackMax = 7;
					//if (NPC.life < NPC.lifeMax*0.75f)
					//	attackMax = 6;
					while (guessAttack == prevAttack) {
						guessAttack = Main.rand.Next(1, attackMax);
						//guessAttack = 6;
					}
				}
				else if (attackMode == 2) {
					NPC.alpha -= 5;
					if (NPC.alpha < 201)
						NPC.friendly = false;
					else
						NPC.position.Y -= 1;
					if (NPC.alpha < 1)
						attackMode = 3;
					if (guessAttack == 1 || guessAttack == 3 || guessAttack == 4)
						LookToPlayer();
					else if (guessAttack == 2 || guessAttack == 5 || guessAttack == 6)
						NPC.rotation = 0f;
					if (guessAttack == 4)
						NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * 1.5f;
				}
				else if (attackMode == 3) {
					attack = guessAttack;
					attackRand = Main.rand.Next(100);
					attackFloat = 0f;
				}
			}
			if (attack == 1 && attackDone == false) {
				attackTimer++;
				if (attackTimer < 180)
				LookToPlayer();
				else {
					if (attackTimer % 5 == 0) {
						SoundEngine.PlaySound(SoundID.NPCHit13, NPC.Center);
						ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 8).RotatedBy(NPC.rotation + Main.rand.NextFloat(-0.4f - (attackBoost*0.02f), 0.4f + (attackBoost*0.02f))), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyLaser>(), 20 + attackBoost, 0f, Main.myPlayer, BasicNetType: 2);
					}
				}
				if (attackTimer > 299) {
					attackDone = true;
					movement = true;
					prevAttack = 1;
				}
			}
			if (attack == 2 && attackDone == false) {
				attackTimer++;
				if (attackTimer % 10 - attackBoost == 0 && attackTimer < 300)
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-600, 601), -600), new Vector2(0, 0), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyBit>(), 20 + attackBoost, 0f, Main.myPlayer, BasicNetType: 2);
				if (attackTimer > 499) {
					attackDone = true;
					movement = true;
					prevAttack = 2;
				}
			}
			if (attack == 3 && attackDone == false) {
				attackTimer++;
				LookToPlayer();
				if (attackTimer % 90 - (attackBoost*6) == 59) {
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<ExplosiveEerieJellyfish>(), 0, attackBoost);
				}
				if (attackTimer > 499) {
					attackDone = true;
					movement = true;
					prevAttack = 3;
				}
			}
			if (attack == 4 && attackDone == false) {
				attackTimer++;
				int startType;
				if (attackRand < 50) startType = 1;
				else startType = -1;
				if (attackTimer % 180 < 90) //(attackRand < 50)
					NPC.rotation += MathHelper.ToRadians(4*startType);
				else
					NPC.rotation -= MathHelper.ToRadians(4*startType);
				if (attackTimer < 350)
					NPC.velocity = (20f + (attackBoost*2)) * new Vector2((float)Math.Cos(NPC.rotation), (float)Math.Sin(NPC.rotation)).RotatedBy(MathHelper.ToRadians(270));
				else
					NPC.velocity /= 2;
				if (attackTimer >= 360) {
					attackDone = true;
					movement = true;
					prevAttack = 4;
				}
				int dustType = ModContent.DustType<Dusts.WaterDust>();
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = NPC.velocity.X * -0.5f;
				dust.velocity.Y = NPC.velocity.Y * -0.5f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				if (attackTimer % 10 - attackBoost == 0) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, NPC.velocity * -0.2f, ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyLaser>(), 20 + attackBoost, 0f, Main.myPlayer, BasicNetType: 2);
				}
			}
			if (attack == 5 && attackDone == false) {
				attackTimer++;
				if (attackTimer < 90) attackFloat += 0.01f + (attackBoost*0.0012f);
				else if (attackTimer < 180) attackFloat -= 0.01f + (attackBoost*0.0012f);
				NPC.rotation += attackFloat; //if (attackTimer < 180) 
				if (((attackTimer % 3 == 0 && NPC.life > NPC.lifeMax / 2) || (attackTimer % 2 == 0 && NPC.life <= NPC.lifeMax / 2)) && attackTimer <= 180)
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 0.3f).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyLaserFast>(), 20 + attackBoost, 0f, Main.myPlayer, BasicNetType: 2);
				if (attackTimer >= 360) {
					attackDone = true;
					movement = true;
					prevAttack = 5;
				}
			}
			if (attack == 6 && attackDone == false) {
				attackTimer++;
				if (attackTimer == 1) {
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)target.Center.X, (int)target.Center.Y - 360, ModContent.NPCType<BeamEerieJellyfish>(), 0, attackBoost, 0f);
				}
				if (attackTimer == 91) {
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)target.Center.X - 540, (int)target.Center.Y, ModContent.NPCType<BeamEerieJellyfish>(), 0, attackBoost, 1f);
				}
				if (attackTimer > 640) {
					attackDone = true;
					movement = true;
					prevAttack = 6;
				}
					
			}
		}
        public override void PostAI() {
            NPC.dontTakeDamage = !Main.player[NPC.target].ZoneBeach;
        }
        private void LookToPlayer() {
			Vector2 look = Main.player[NPC.target].Center - NPC.Center;
			LookInDirection(look);
		}
		private void LookInDirection(Vector2 look) {
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f) {
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f) {
				angle += (float)Math.PI;
			}
			if (look.X < 0f) {
				angle += (float)Math.PI;
			}
			NPC.rotation = angle + MathHelper.ToRadians(270);
		}
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.HealingPotion;
			ZylonWorldCheckSystem.downedJelly = true;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("A mysterious and massive jellyfish that roams the ocean.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (Main.masterMode) {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Relics.JellyRelic>(), 1));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.EldritchGland>(), 4));
            }
			if (Main.expertMode || Main.masterMode) npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bags.JellyBag>(), 1));
			else {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.EerieBell>(), 1, 30, 45));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.OtherworldlyFang>(), 1, 35, 50));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.JellyMask>(), 7));
            }
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.JellyTrophy>(), 10));
		}
    }
}