using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Bosses.Metelord
{
	[AutoloadBossHead]
	internal class MetelordHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<MetelordBody>();
		public override int TailType => ModContent.NPCType<MetelordTail>();
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");
			Main.npcFrameCount[NPC.type] = 2;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/Bosses/Metelord/Metelord_Bestiary",
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = (int)(2800*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 36;
			NPC.defense = 6;
			NPC.value = 50000;
			NPC.height = 52;
			NPC.width = 52;
			NPC.noGravity = true;
			CanFly = true;
			NPC.boss = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.lifeMax = (int)((4200 + ((numPlayers - 1) * 1600))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 64;
			if (Main.masterMode) {
				NPC.lifeMax = (int)((5600 + ((numPlayers - 1) * 2100))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 92;
            }
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
				new FlavorTextBestiaryInfoElement("While most meteor spawn are very small in size, some can be formed from a chain of meteor chunks, leading to them forming a worm-like being.")
			});
		}
		public override void Init() {
			MinSegmentLength = 6;
			MaxSegmentLength = 6;

			CommonWormInit(this);
		}
		internal static void CommonWormInit(Worm worm) {
			worm.MoveSpeed = 12f;
			worm.Acceleration = 0.105f;
			if (Main.expertMode) {
				worm.MoveSpeed = 14f;
				worm.Acceleration = 0.125f;
			}
		}
		private int attackCounter;
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write(attackCounter);
		}
		public override void ReceiveExtraAI(BinaryReader reader) {
			attackCounter = reader.ReadInt32();
		}
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) NPC.ai[0] = 1;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) NPC.ai[0] = 1;
        }
        Player target;
        public override void AI() {
			NPC.active = false;
			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.metelordBoss = NPC.whoAmI;
        }
		int attack;
		int attackTimer;
		int attackTimer2;
		int attackInt;
		int prevAttack;
		int attackMax = 3;
		int runBoost = 180;
		bool attackDone = true;
		Vector2 newVel;
        public override void PostAI() {
			if (attackDone) {
				attackTimer2++;
				if (attackTimer2 > (int)(30+(150*NPC.life/NPC.lifeMax)+runBoost)) {
					attack = Main.rand.Next(attackMax);
					while (attack == prevAttack) attack = Main.rand.Next(attackMax);
					prevAttack = attack;
					attackDone = false;
					attackTimer = 0;
					attackTimer2 = 0;
					runBoost = 0;
					newVel = new Vector2();
					attackInt = 0; //Fun story: I forgot to put this in and as I was testing the boss, I thought to myself: "It's almost like attackInt isn't reset-OHHHH!"

					//attack = 2;
                }
            }
			else if (attack == 0) {
				runBoost = 30;
				if (attackTimer <= 0) {
					if (attackInt >= (int)(8-(6*NPC.life/NPC.lifeMax))) attackDone = true;
					else {
						attackTimer = (int)(50+(40*NPC.life/NPC.lifeMax));
						Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
						speed.Normalize();
						newVel = speed*(int)(-18f+(5f*NPC.life/NPC.lifeMax));
						attackInt++;
					}
                }
				else {
					newVel *= (0.994f-(0.002f*NPC.life/NPC.lifeMax));
					attackTimer--;
					if (attackTimer % 10 == 0) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireTrail>(), (int)(NPC.damage*0.2f), 0f);
					/*if (attackTimer == 30 && NPC.life < NPC.lifeMax*0.66f) {
						Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
						if (Math.Abs(speed.X)+Math.Abs(speed.Y) > 128)
						speed.Normalize();*/
						/*Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
						speed *= -1;
						speed.Normalize();
						Vector2 speed2 = NPC.velocity;
						speed2.Normalize();
						if (Math.Acos(Vector2.Dot(speed, speed2)) < 0) {
                            NPC.velocity = speed * (int)(18f - (5f * NPC.life / NPC.lifeMax));
							SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                        }*/
                    //}
				NPC.velocity = newVel;
				}
			}
			else if (attack == 1) {
				/*if (attackInt == 0) {
					newVel = new Vector2(0, -9);
					if (NPC.Center.Y < (target.Center.Y-300))
						attackInt = 1;
                }
				if (attackInt == 1) {
					if (attackTimer == 0) newVel.Y /= 2;*/
					attackTimer++;
				int counter = 3;
				if ((Main.expertMode && NPC.life < NPC.lifeMax*0.5f) || NPC.life < NPC.lifeMax*0.33f) counter = 2;
				if (NPC.Center.X < (target.Center.X+(target.velocity.X*24)) && attackTimer % counter == 0)
					newVel.X += 1;
				else if (attackTimer % counter == 0)
					newVel.X -= 1;
				int num69 = (int)(17-(7*NPC.life/NPC.lifeMax));
				if (newVel.X > num69) newVel.X = num69;
				if (newVel.X < -1*num69) newVel.X = -1*num69;
				if (NPC.Center.Y < (target.Center.Y-300) && attackTimer % 3 == 0)
					newVel.Y += 1;
				else if (attackTimer % 3 == 0)
					newVel.Y -= 1;
				if (newVel.Y > 10) newVel.Y = 10;
				if (newVel.Y < -10) newVel.Y = -10;
				if (attackTimer % 12 == 0) {
					int projType;
					if (Main.rand.NextBool(3)) projType = ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireDrop1>();
					else if (Main.rand.NextBool(2)) projType = ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireDrop2>();
					else projType = ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireDrop3>();
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-6, 3)), projType, (int)(NPC.damage*0.19f), 0f);
                }
				if (attackTimer > 359) attackDone = true;
				NPC.velocity = newVel;
            }
			else if (attack == 2) {
				runBoost = 75;
				attackTimer++;
				if (attackTimer % (int)(30-(15*NPC.life/NPC.lifeMax)) == 0) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-100, 101)+(target.velocity.X*32), 0), new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordMeteoriteAttack2>(), (int)(NPC.damage*0.25f), 0f, Main.myPlayer, Main.rand.Next(0, 360), 5f-(2f*NPC.life/NPC.lifeMax));
                }
				if (attackTimer > 300) attackDone = true;
            }
			/*else if (attack == 2) { //scrapped version of meteor ring
				if (attackTimer == 0 && attackInt == 0) newVel = NPC.velocity;
				attackTimer++;
				if (attackTimer >= 180) {
					int j = Main.rand.Next(0, 12);
					int k = 1;
					if (Main.rand.NextBool()) k = -1;
					for (int i = 0; i < 11; i++) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordMeteoriteAttack>(), (int)(NPC.damage*0.3f), 0f, Main.myPlayer, i+j, k);
                    }
					attackTimer = 0;
					attackInt++;
                }
				newVel *= 0.99f;
				//NPC.velocity = newVel;
				if (attackInt == 3) attackDone = true;
            }*/
            if (!target.ZoneMeteor) {
				NPC.damage = 74;
				if (Main.expertMode) NPC.damage = 128;
				if (Main.masterMode) NPC.damage = 184;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 18;
				for (int i = 0; i < 2; i++) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity = NPC.velocity;
					dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
			else {
				NPC.damage = 36;
				if (Main.expertMode) NPC.damage = 64;
				if (Main.masterMode) NPC.damage = 92;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 6;
				if (Main.rand.NextBool()) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity = NPC.velocity;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
			if (NPC.rotation > MathHelper.Pi) { 
				NPC.frame.Y = 52;
			}
			else NPC.frame.Y = 0;
        }
        /*public override void AI() {
			if (Main.netMode != NetmodeID.MultiplayerClient) {
				if (attackCounter > 0) {
					attackCounter--;
				}
				Player target = Main.player[NPC.target];
				// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1)) {
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

					int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.ShadowBeamHostile, 5, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 300;
					attackCounter = 500;
					NPC.netUpdate = true;
				}
			}
		}*/
        public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 6));
        }
		/*public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Vertebrae, 1, 1, 3));
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.BloodySpiderLeg>(), 1, 2, 6));
			npcLoot.Add(new CommonDrop(ItemID.Ichor, 1, 3, 9));
		}*/
	}
	internal class MetelordBody : WormBody
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.damage = 32;
			NPC.defense = 39;
			NPC.width = 38;
			NPC.height = 38;
			NPC.noGravity = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.damage = 60;
			if (Main.masterMode) {
				NPC.damage = 88;
            }
		}
        public override void Init() {
			MetelordHead.CommonWormInit(this);
		}
		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) head.ai[0] = 1;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) head.ai[0] = 1;
			projectile.damage /= 2; //noooo! you can't just stop me from piercing the worm boss to death!
        }
		Player target;
		NPC head;
        public override void AI() {
			head = Main.npc[ZylonGlobalNPC.metelordBoss];
            target = Main.player[head.target];
        }
		public override void PostAI() {
            if (!target.ZoneMeteor) {
				NPC.damage = 64;
				if (Main.expertMode) NPC.damage = 120;
				if (Main.masterMode) NPC.damage = 176;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 117;
				for (int i = 0; i < 2; i++) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity = NPC.velocity;
					dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
			else {
				NPC.damage = 32;
				if (Main.expertMode) NPC.damage = 60;
				if (Main.masterMode) NPC.damage = 88;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 39;
				if (Main.rand.NextBool()) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity = NPC.velocity;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 5));
        }
	}

	internal class MetelordTail : WormTail
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metelord");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Confused,
					BuffID.Slow,
					BuffID.OnFire,
					BuffID.OnFire3,
					BuffID.CursedInferno,
					BuffID.Frostburn,
					BuffID.Frostburn2,
					BuffID.Frozen,
					BuffID.ShadowFlame
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.damage = 20;
			NPC.defense = 198;
			NPC.width = 40;
			NPC.height = 40;
			NPC.noGravity = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.damage = 40;
			if (Main.masterMode) {
				NPC.damage = 60;
            }
		}
		public override void Init() {
			MetelordHead.CommonWormInit(this);
		}
		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) head.ai[0] = 1;
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit) {
            if (target.ZoneMeteor) head.ai[0] = 1;
        }
		Player target;
		NPC head;
        public override void AI() {
			head = Main.npc[ZylonGlobalNPC.metelordBoss];
            target = Main.player[head.target];
        }
		public override void PostAI() {
            if (!target.ZoneMeteor) {
				NPC.damage = 40;
				if (Main.expertMode) NPC.damage = 80;
				if (Main.masterMode) NPC.damage = 120;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 396;
				for (int i = 0; i < 2; i++) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity = NPC.velocity;
					dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
			else {
				NPC.damage = 20;
				if (Main.expertMode) NPC.damage = 40;
				if (Main.masterMode) NPC.damage = 60;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 198;
				if (Main.rand.NextBool()) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity = NPC.velocity;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 5));
        }
	}
}