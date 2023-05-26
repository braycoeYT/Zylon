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

			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			DisplayName.SetDefault("Metelord");
			//Main.npcFrameCount[NPC.type] = 2;
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
					BuffID.ShadowFlame,
					ModContent.BuffType<Buffs.Debuffs.Timestop>()
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = (int)(5500*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 36;
			NPC.defense = 6;
			NPC.value = 50000;
			NPC.height = 52;
			NPC.width = 26; //34
			NPC.noGravity = true;
			CanFly = true;
			NPC.boss = true;
			NPC.lavaImmune = true;
			Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/BolideSerpent");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			NPC.lifeMax = (int)((7000 + ((numPlayers - 1) * 4900))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 64;
			if (Main.masterMode) {
				NPC.lifeMax = (int)((8500 + ((numPlayers - 1) * 6400))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
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
			MinSegmentLength = 6; //5
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
			if (projectile.aiStyle == 1 || projectile.aiStyle == 2 || projectile.aiStyle == 3 || projectile.aiStyle == 5 || projectile.aiStyle == 8 || projectile.aiStyle == 12 || projectile.aiStyle == 13 || projectile.aiStyle == 14 || projectile.aiStyle == 15 || projectile.aiStyle == 18 || projectile.aiStyle == 23 || projectile.aiStyle == 24 || projectile.aiStyle == 27 || projectile.aiStyle == 28 || projectile.aiStyle == 29 || projectile.aiStyle == 30 || projectile.aiStyle == 33 || projectile.aiStyle == 34 || projectile.aiStyle == 36 || projectile.aiStyle == 38 || projectile.aiStyle == 39 || projectile.aiStyle == 40 || projectile.aiStyle == 41 || projectile.aiStyle == 42 || projectile.aiStyle == 43 || projectile.aiStyle == 44 || projectile.aiStyle == 45 || projectile.aiStyle == 46 || projectile.aiStyle == 47 || projectile.aiStyle == 48 || projectile.aiStyle == 50 || projectile.aiStyle == 51 || projectile.aiStyle == 57 || projectile.aiStyle == 65 || projectile.aiStyle == 69 || projectile.aiStyle == 70 || projectile.aiStyle == 71 || projectile.aiStyle == 72 || projectile.aiStyle == 73 || projectile.aiStyle == 74 || projectile.aiStyle == 75 || projectile.aiStyle == 77 || projectile.aiStyle == 78 || projectile.aiStyle == 81 || projectile.aiStyle == 84 || projectile.aiStyle == 87 || projectile.aiStyle == 91 || projectile.aiStyle == 92 || projectile.aiStyle == 93 || projectile.aiStyle == 94 || projectile.aiStyle == 95 || projectile.aiStyle == 96 || projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()) //stopped before 100 because this is just getting absurd
			if (!(projectile.DamageType == DamageClass.Summon || projectile.DamageType == DamageClass.MagicSummonHybrid) || (projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>())) {
				Vector2 temp = projectile.velocity;
				temp.Normalize();
				projectile.velocity = temp*-16f;
            }
        }
        Player target;
        public override void AI() {
			//NPC.active = false;
			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.metelordBoss = NPC.whoAmI;
			if (NPC.life < 1 && spawnGore) {
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-3, -0)), ModContent.GoreType<Gores.Bosses.Metelord.MetelordHeadGore>());
				spawnGore = false;
            }
        }
		int Timer;
		int attack;
		int attackTimer;
		int attackTimer2;
		int attackInt;
		int prevAttack;
		int attackMax = 4;
		int runBoost = 180;
		int flee;
		bool attackDone = true;
		bool spawnGore = true;
		Vector2 newVel;
        public override void PostAI() {
			NPC.TargetClosest(true);
			Timer++;
			if (Main.player[NPC.target].statLife < 1) {
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					//if (flee == 0)
					flee++;
				}
				else
				flee = 0;
				if (flee > 0) {
					if (flee == 1) newVel = Vector2.Zero;
					if (Timer % 10 == 0)
					newVel.Y += 1;
					NPC.velocity = newVel;
					if (flee > 300) NPC.active = false;
					return;
				}
			}
			if (attackDone) {
				NPC.ai[1] = 0;
				attackTimer2++;
				if (attackTimer2 > (int)(30+(150*NPC.life/NPC.lifeMax)+runBoost)) {
					attackMax = 3;
					float expertBoost = 0f;
					if (Main.expertMode) expertBoost = 0.125f;
					if (NPC.life <= NPC.lifeMax*(0.75f+expertBoost)) attackMax = 4;
					if (NPC.life <= NPC.lifeMax*(0.625f+expertBoost)) attackMax = 5;
					if (NPC.life <= NPC.lifeMax*(0.5f+expertBoost)) attackMax = 6;
					if (NPC.life <= NPC.lifeMax*(0.2f+expertBoost)) attackMax = 7;

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
						newVel = speed*(int)(-20f+(5f*NPC.life/NPC.lifeMax));
						attackInt++;
					}
                }
				else {
					newVel *= (0.994f-(0.002f*NPC.life/NPC.lifeMax));
					attackTimer--;
					if (attackTimer % 15 == 0) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireTrail>(), (int)(NPC.damage*0.2f), 0f, BasicNetType: 2);
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
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-6, 3)), projType, (int)(NPC.damage*0.19f), 0f, BasicNetType: 2);
                }
				if (attackTimer > 359) attackDone = true;
				NPC.velocity = newVel;
            }
			else if (attack == 2) {
				runBoost = 75;
				attackTimer++;
				newVel *= 0.99f;
				if (attackTimer % (int)(35+(20*NPC.life/NPC.lifeMax)) == 1) {
					Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
					speed.Normalize();
					newVel = speed*(int)(-10f-(2f*NPC.life/NPC.lifeMax)); //-11.5f
                }
				if (attackTimer % (int)(15+(25*NPC.life/NPC.lifeMax)) == 0) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-100, 101)+(target.velocity.X*32), 0), new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordMeteoriteAttack2>(), (int)(NPC.damage*0.25f), 0f, Main.myPlayer, Main.rand.Next(0, 360), 5f-(2f*NPC.life/NPC.lifeMax), BasicNetType: 2);
                }
				if (attackTimer > 300) attackDone = true;
				NPC.velocity = newVel;
            }
			else if (attack == 3) {
				if (attackTimer % (100+(20*NPC.life/NPC.lifeMax)) == 0) {
					Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
					speed.Normalize();
					if (speed.Length() == 0) speed = new Vector2(0, -1);
					newVel = speed*(int)(-16f+(4f*NPC.life/NPC.lifeMax));
                }
				if (attackTimer % (100+(20*NPC.life/NPC.lifeMax)) <= 30) {
					NPC.velocity = newVel;
					newVel *= 0.992f;
					if (attackTimer % 4 == 0) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -15).RotatedBy(NPC.rotation+Main.rand.NextFloat(-0.2f, 0.2f)), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordBallofFire>(), (int)(NPC.damage*0.22f), 0f, BasicNetType: 2);
                }
				attackTimer++;
				if (attackTimer == (290+(60*NPC.life/NPC.lifeMax))) attackDone = true;
            }
			else if (attack == 4) {
				runBoost = 30;
				attackTimer++;
				attackTimer2++;
				if (attackTimer % (int)(5+(5*NPC.life/NPC.lifeMax)) == 0 && attackTimer2 % 180 < 90) {
					ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -15).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordFireBreath>(), (int)(NPC.damage * 0.33f), 0f, Main.myPlayer, 30 - (30 * NPC.life / NPC.lifeMax), BasicNetType: 2);
				}
				if (attackTimer % (100+(50*NPC.life/NPC.lifeMax)) < (55+(15*NPC.life/NPC.lifeMax))) {
					Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
					speed.Normalize();
					float evilness = 0;
					float kindness = 0;
					float basedness = 1;
					if (!target.ZoneMeteor) evilness = (3f*NPC.life/NPC.lifeMax);
					if (!Main.expertMode) kindness = 2f;
					if (attackTimer % (100+(50*NPC.life/NPC.lifeMax)) < 20) basedness = 0.05f*(attackTimer % (100+(50*NPC.life/NPC.lifeMax)));
					speed *= basedness;
					newVel = speed*(int)(-10f-evilness+kindness+(3f*NPC.life/NPC.lifeMax));
                }
				if (attackTimer % (100+(50*NPC.life/NPC.lifeMax)) > (100+(50*NPC.life/NPC.lifeMax))-10) newVel *= 0.8f;
				if (attackTimer < (44+(14*NPC.life/NPC.lifeMax))) newVel /= 2;
				NPC.velocity = newVel;
				if (attackTimer > 360) attackDone = true;
            }
			else if (attack == 5 || attack == 6) {
				runBoost = 120+(180*NPC.life/NPC.lifeMax);
				attackTimer++;
				NPC.ai[1] = 1;
				if (attackTimer <= 8) { 
					Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
					speed.Normalize();
					newVel = speed*(int)(-32.5f+(5f*NPC.life/NPC.lifeMax));
				}
				NPC.velocity = newVel;
				newVel *= 0.975f;
				if (attackTimer == 90) {
					SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
					float randomizer = Main.rand.NextFloat(MathHelper.TwoPi);
					float boost = 1.5f-(0.5f*NPC.life/NPC.lifeMax);
					int j = (int)(6*boost);
					for (int i = 0; i < j; i++) {
						ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 5f*boost).RotatedBy(MathHelper.ToRadians(i*(360/j))+randomizer), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordDMFireball>(), (int)(NPC.damage*0.35f), 0f, BasicNetType: 2);
                    }
					randomizer = Main.rand.NextFloat(MathHelper.TwoPi);
					j = (int)(10*boost);
					for (int i = 0; i < j; i++) {
						ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 7.5f*boost).RotatedBy(MathHelper.ToRadians(i*(360/j))+randomizer), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordDMFireball>(), (int)(NPC.damage*0.35f), 0f, BasicNetType: 2);
                    }
					randomizer = Main.rand.NextFloat(MathHelper.TwoPi);
					j = (int)(16*boost);
					for (int i = 0; i < j; i++) {
						ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 10f*boost).RotatedBy(MathHelper.ToRadians(i*(360/j))+randomizer), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordDMFireball>(), (int)(NPC.damage*0.35f), 0f, BasicNetType: 2);
                    }
                }
				if (attackTimer > 30 && attackTimer < 90)
					NPC.Center += new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4));
				if (attackTimer == 120) attackDone = true;
            }
			/*else if (attack == 3) { //scrapped fireball spit attack
				runBoost = 60;
				if (attackInt == 0) {
					attackTimer++;
					if (attackTimer > 50) attackTimer = 50;
					newVel.Y = -13f*(1+(attackTimer/100));
					if (attackTimer == 1) newVel.X = NPC.velocity.X;
					else newVel.X *= 0.8f;
					if (attackTimer > 20 && NPC.Center.Y+400 < target.Center.Y) {
						attackTimer = 0;
						attackInt = 1;
                    }
                }
				if (attackInt == 1) {
					Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
					speed.Normalize();
					newVel = speed*(int)(-20f+(5f*NPC.life/NPC.lifeMax));
					attackInt = 2;
                }
				if (attackInt == 2) {
					newVel *= 0.992f;
					attackTimer++;
                }
				NPC.velocity = newVel;
            }*/
			/*else if (attack == 4) { //early scrapped version of flamethrower dash
				attackTimer++;
				/*if (attackTimer % (int)(10+(10*NPC.life/NPC.lifeMax)) == 0) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -10).RotatedBy(NPC.rotation+Main.rand.NextFloat(-0.1f, 0.1f)), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MetelordBallofFire>(), (int)(NPC.damage*0.23f), 0f);
                }*/
				/*if (attackInt == 0) {
					int tempInt = 1;
					if (Main.rand.NextBool()) tempInt = -1;
					newVel = new Vector2(10*tempInt, 0);
					attackInt = 1;
                }
				if (attackInt == 1) {
					newVel *= 0.992f;

                }
				NPC.velocity = newVel;
            }*/
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
			/*if (Main.npc[ZylonGlobalNPC.metelordBoss].life < 1 && spawnGore && Main.netMode != NetmodeID.MultiplayerClient) {
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), 0), ModContent.GoreType<Gores.Bosses.Metelord.MetelordHeadGore>());
				spawnGore = false;
			}*/
			/*if (NPC.rotation > MathHelper.Pi) { //for old sprite
				NPC.frame.Y = 52;
			}
			else NPC.frame.Y = 0;*/
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
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.RestorationPotion;
			ZylonWorldCheckSystem.downedMetelord = true;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (Main.masterMode) {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Relics.MetelordRelic>(), 1));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.PlasticDinoFigurine>(), 4));
            }
			if (Main.expertMode || Main.masterMode) npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bags.MetelordBag>(), 1));
			else {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Ores.HaxoniteOre>(), 1, 80, 100));
				npcLoot.Add(ItemDropRule.Common(ItemID.Meteorite, 1, 15, 30));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.MetelordMask>(), 7));
            }
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.MetelordTrophy>(), 10));
		}
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
					BuffID.ShadowFlame,
					ModContent.BuffType<Buffs.Debuffs.Timestop>()
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.damage = 32;
			NPC.defense = 12;
			NPC.width = 38; //44
			NPC.height = 36;
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
			if (projectile.aiStyle == 1 || projectile.aiStyle == 2 || projectile.aiStyle == 3 || projectile.aiStyle == 5 || projectile.aiStyle == 8 || projectile.aiStyle == 12 || projectile.aiStyle == 13 || projectile.aiStyle == 14 || projectile.aiStyle == 15 || projectile.aiStyle == 18 || projectile.aiStyle == 23 || projectile.aiStyle == 24 || projectile.aiStyle == 27 || projectile.aiStyle == 28 || projectile.aiStyle == 29 || projectile.aiStyle == 30 || projectile.aiStyle == 33 || projectile.aiStyle == 34 || projectile.aiStyle == 36 || projectile.aiStyle == 38 || projectile.aiStyle == 39 || projectile.aiStyle == 40 || projectile.aiStyle == 41 || projectile.aiStyle == 42 || projectile.aiStyle == 43 || projectile.aiStyle == 44 || projectile.aiStyle == 45 || projectile.aiStyle == 46 || projectile.aiStyle == 47 || projectile.aiStyle == 48 || projectile.aiStyle == 50 || projectile.aiStyle == 51 || projectile.aiStyle == 57 || projectile.aiStyle == 65 || projectile.aiStyle == 69 || projectile.aiStyle == 70 || projectile.aiStyle == 71 || projectile.aiStyle == 72 || projectile.aiStyle == 73 || projectile.aiStyle == 74 || projectile.aiStyle == 75 || projectile.aiStyle == 77 || projectile.aiStyle == 78 || projectile.aiStyle == 81 || projectile.aiStyle == 84 || projectile.aiStyle == 87 || projectile.aiStyle == 91 || projectile.aiStyle == 92 || projectile.aiStyle == 93 || projectile.aiStyle == 94 || projectile.aiStyle == 95 || projectile.aiStyle == 96 || projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()) //stopped before 100 because this is just getting absurd
			if (!(projectile.DamageType == DamageClass.Summon || projectile.DamageType == DamageClass.MagicSummonHybrid) || (projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>())) {
				Vector2 temp = projectile.velocity;
				temp.Normalize();
				projectile.velocity = temp*-16f;
            }
			//if (projectile.type == ModContent.ProjectileType<Projectiles.Misc.AquaBubble>()) projectile.Kill();
        }
		Player target;
		NPC head;
        public override void AI() {
			head = Main.npc[ZylonGlobalNPC.metelordBoss];
            target = Main.player[head.target];
			if (NPC.life < 1 && spawnGore) {
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-3, 0)), ModContent.GoreType<Gores.Bosses.Metelord.MetelordTailGore>());
				spawnGore = false;
            }
        }
		bool spawnGore = true;
		public override void PostAI() {
			if (head.ai[1] == 1) NPC.Center += new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4));
            if (!target.ZoneMeteor) {
				NPC.damage = 64;
				if (Main.expertMode) NPC.damage = 120;
				if (Main.masterMode) NPC.damage = 176;
				NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
				NPC.defense = 36;
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
				NPC.defense = 12;
				if (Main.rand.NextBool()) {
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
					Dust dust = Main.dust[dustIndex];
					//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity = NPC.velocity;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
            }
			/*if (Main.npc[ZylonGlobalNPC.metelordBoss].life < 1 && spawnGore && Main.netMode != NetmodeID.MultiplayerClient) {
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), 0), ModContent.GoreType<Gores.Bosses.Metelord.MetelordBodyGore>());
				spawnGore = false;
			}*/
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
					BuffID.ShadowFlame,
					ModContent.BuffType<Buffs.Debuffs.Timestop>()
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}
		public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
			NPC.damage = 20;
			NPC.defense = 198;
			NPC.width = 46;
			NPC.height = 46;
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
			if (projectile.aiStyle == 1 || projectile.aiStyle == 2 || projectile.aiStyle == 3 || projectile.aiStyle == 5 || projectile.aiStyle == 8 || projectile.aiStyle == 12 || projectile.aiStyle == 13 || projectile.aiStyle == 14 || projectile.aiStyle == 15 || projectile.aiStyle == 18 || projectile.aiStyle == 23 || projectile.aiStyle == 24 || projectile.aiStyle == 27 || projectile.aiStyle == 28 || projectile.aiStyle == 29 || projectile.aiStyle == 30 || projectile.aiStyle == 33 || projectile.aiStyle == 34 || projectile.aiStyle == 36 || projectile.aiStyle == 38 || projectile.aiStyle == 39 || projectile.aiStyle == 40 || projectile.aiStyle == 41 || projectile.aiStyle == 42 || projectile.aiStyle == 43 || projectile.aiStyle == 44 || projectile.aiStyle == 45 || projectile.aiStyle == 46 || projectile.aiStyle == 47 || projectile.aiStyle == 48 || projectile.aiStyle == 50 || projectile.aiStyle == 51 || projectile.aiStyle == 57 || projectile.aiStyle == 65 || projectile.aiStyle == 69 || projectile.aiStyle == 70 || projectile.aiStyle == 71 || projectile.aiStyle == 72 || projectile.aiStyle == 73 || projectile.aiStyle == 74 || projectile.aiStyle == 75 || projectile.aiStyle == 77 || projectile.aiStyle == 78 || projectile.aiStyle == 81 || projectile.aiStyle == 84 || projectile.aiStyle == 87 || projectile.aiStyle == 91 || projectile.aiStyle == 92 || projectile.aiStyle == 93 || projectile.aiStyle == 94 || projectile.aiStyle == 95 || projectile.aiStyle == 96 || projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()) //stopped before 100 because this is just getting absurd
			if (!(projectile.DamageType == DamageClass.Summon || projectile.DamageType == DamageClass.MagicSummonHybrid) || (projectile.type == ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>())) {
				Vector2 temp = projectile.velocity;
				temp.Normalize();
				projectile.velocity = temp*-16f;
            }
        }
		Player target;
		NPC head;
        public override void AI() {
			head = Main.npc[ZylonGlobalNPC.metelordBoss];
            target = Main.player[head.target];
			if (NPC.life < 1 && spawnGore) {
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-3, 0)), ModContent.GoreType<Gores.Bosses.Metelord.MetelordBodyGore>());
				spawnGore = false;
            }
        }
		bool spawnGore = true;
		public override void PostAI() {
			if (head.ai[1] == 1) NPC.Center += new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4));
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
			/*if (Main.npc[ZylonGlobalNPC.metelordBoss].life < 1 && spawnGore && Main.netMode != NetmodeID.MultiplayerClient) {
				int deezNuts = ModContent.GoreType<Gores.Bosses.Metelord.MetelordTailGore>();
				//if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges) deezNuts = ModContent.GoreType<Gores.Bosses.Metelord.MetelordHeadGore>();
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), 0), deezNuts);
				spawnGore = false;
			}*/
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 5));
        }
	}
}