using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Dirtball
{
	[AutoloadBossHead]
    public class Dirtball : ModNPC
	{
        public override void SetStaticDefaults() {

			NPCID.Sets.BossBestiaryPriority.Add(Type);
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			Main.npcFrameCount[NPC.type] = 3;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
		}
        public override void SetDefaults() {
            NPC.width = 80;
			NPC.height = 70;
			NPC.damage = 31;
			NPC.defense = 10;
			NPC.lifeMax = (int)(1500*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 7500;
			NPC.aiStyle = -1; //14
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DirtStep");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)((2100 + ((numPlayers - 1) * 900))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 46;
			NPC.value = 20000;
			if (Main.masterMode) {
				NPC.lifeMax = (int)((2700 + ((numPlayers - 1) * 1200))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 55;
            }
			if (Main.getGoodWorld) NPC.scale = 0.75f;
        }
		bool bool1;
		bool bool2;
		public override void HitEffect(NPC.HitInfo hit) {
			for (int i = 0; i < (3-phase)*4; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Dirt);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			for (int i = 0; i < (phase-1)*3; i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Iron);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (!bool1 && NPC.life < NPC.lifeMax*(0.6f+expertBoost)) {
				for (int i = 0; i < 10; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(0, 6)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtChunkGore>());
				bool1 = true;
            }
			if (!bool2 && NPC.life < NPC.lifeMax*(0.3f+expertBoost)) {
				for (int i = 0; i < 10; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-3, 5)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtChunkGore>());
				bool2 = true;
            }
			if (NPC.life < 1) {
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-2, 4)), ModContent.GoreType<Gores.Bosses.Dirtball.DBDead1>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-2, 4)), ModContent.GoreType<Gores.Bosses.Dirtball.DBDead2>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-2, 4)), ModContent.GoreType<Gores.Bosses.Dirtball.DBDead3>());
				Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-2, 4)), ModContent.GoreType<Gores.Bosses.Dirtball.DBDead4>());
				ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DBSpirit>(), 0, 0f, BasicNetType: 2);
			}
		}
        public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone) {
            if (phase == 2) {
				if (player.Center.Y < NPC.Center.Y) SoundEngine.PlaySound(SoundID.NPCHit1, NPC.Center);
				else SoundEngine.PlaySound(SoundID.NPCHit4, NPC.Center);
            }
        }
        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone) {
			if (phase == 2) {
				if (projectile.Center.Y < NPC.Center.Y) SoundEngine.PlaySound(SoundID.NPCHit1, NPC.Center);
				else SoundEngine.PlaySound(SoundID.NPCHit4, NPC.Center);
            }
        }
        public override void PostAI() {
			for (int i = 0; i < (3-phase); i++) {
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Dirt);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		float expertBoost;
		float speedBoost;
		int phase;
		int attack;
		int attackTimer;
		int attackInt;
		int prevAttack;
		int attackMax;
		int Timer;
		int atkTotal;
		int yvel;
		int flee;
		bool attackDone = true;
		bool attackBool;
		bool init;
		bool movement;
        public override void AI() { //exp hit dirtblock = penetrate -, -1 = 3
			Timer++;
			speedBoost = 0.75f + (phase*0.25f);
			Vector2 calc = Main.player[NPC.target].Center - NPC.Center;
			float dist = calc.Length();
			if (dist > 800f && Timer > 420) //800f or 1000f?
			speedBoost = 5f;
			NPC.TargetClosest(true);
			ZylonGlobalNPC.dirtballBoss = NPC.whoAmI;
			if (!init) {
				if (Main.expertMode) {
					for (int i = 0; i < 50; i++) {
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + Main.rand.Next(-60, 61), (int)NPC.Center.Y + Main.rand.Next(-60, 61), ModContent.NPCType<DirtBlock>());
					}
					expertBoost = 0.075f;
				}
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Dirtboi>());
				init = true;
				//if (Main.GameModeInfo.)// && Main.GameModeInfo.EnemyMaxLifeMultiplier > 1) //doesn't work sadly
				//	NPC.lifeMax = (int)(NPC.lifeMax/Main.GameModeInfo.EnemyMaxLifeMultiplier);
            }

			if (Main.getGoodWorld && Timer % 150 == 0 && NPC.CountNPCS(ModContent.NPCType<DirtBlock>()) < 50) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + Main.rand.Next(-60, 61), (int)NPC.Center.Y + Main.rand.Next(-60, 61), ModContent.NPCType<DirtBlock>());

			if (Main.player[NPC.target].statLife < 1) {
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
				if (flee > 0) {
					if (Timer % 3 == 0)
					NPC.velocity.Y += 1;
					return;
				}
			}

			phase = 1;
			if (NPC.life < NPC.lifeMax*(0.6f+expertBoost)) phase = 2;
			if (NPC.life < NPC.lifeMax*(0.3f+expertBoost)) phase = 3;
			if (phase == 2) NPC.HitSound = null;
			if (phase == 3) NPC.HitSound = SoundID.NPCHit4;
			NPC.frame.Y = 90*(phase-1);
			NPC.defense = 20-(phase*4);
			NPC.damage = 31;
			if (Main.expertMode) NPC.damage = 46;
			if (Main.masterMode) NPC.damage = 55;
			NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));
			if (Main.getGoodWorld) NPC.damage = (int)(NPC.damage*1.33f);
			if (NPC.CountNPCS(ModContent.NPCType<Dirtboi>()) < 1) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Dirtboi>()); //Dirtboi, my boy, a true ball of dirt never runs away from battle!
			if (attackDone) {
				atkTotal += 1;
				if (phase == 1) attackMax = 6;
				else attackMax = 6;
				attack = Main.rand.Next(attackMax);
				while (attack == prevAttack) attack = Main.rand.Next(attackMax);
				//attack = 5;
				if (attack == 5 && ((phase < 3 && NPC.CountNPCS(ModContent.NPCType<DirtBlock>()) > 29) || (phase > 1 && NPC.CountNPCS(ModContent.NPCType<DS_17>()) > 4)))
					while (attack == prevAttack || attack == 5) attack = Main.rand.Next(attackMax);

				if (atkTotal == 1) attack = 0;

				prevAttack = attack;
				attackDone = false;
				attackTimer = 0;
				attackInt = 0;
				attackBool = false;
				//movement = true;

				//attack = 2;
            }
			if (attack == 0) {
				attackTimer++;
				Vector2 speed = NPC.Center - Main.player[NPC.target].Center;
				movement = attackTimer % (90 + (int)(30*NPC.life/NPC.lifeMax)) < (30 + (int)(30*NPC.life/NPC.lifeMax)) || dist > 600f;
				if (movement == false) NPC.velocity *= 0.98f;
				if (attackTimer % (90 + (int)(30*NPC.life/NPC.lifeMax)) == 0 && attackInt < 3) {
					if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*(-7-(3*NPC.life/NPC.lifeMax)), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage*0.25f), 0f, BasicNetType: 2);
					else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, speed*(-5-(2*NPC.life/NPC.lifeMax)), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>(), (int)(NPC.damage*0.2f), 0f, BasicNetType: 2);
					attackInt++;
				}
				if (attackInt == 3) {
					attackTimer = 0;
					attackInt = 4;
                }
				if (attackInt == 4 && attackTimer > 30 + (int)(30*NPC.life/NPC.lifeMax))
					attackDone = true;
			}
			else if (attack == 1) {
				if (!attackBool) {
					movement = false;
					NPC.velocity *= 0.98f;
					attackTimer++;
					if (attackTimer > 60) {
						attackTimer = 0;
						attackBool = true;
						NPC.velocity = new Vector2();
                    }
					else return;
                }
				movement = dist > 1000f;
				//NPC.life = attackInt + 1000;
				//speedBoost *= 0.5f;
				attackInt++;
				if (attackInt < (35 - (phase*5))) {
					int proj = ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtBallHostile>();
					if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) proj = ModContent.ProjectileType<Projectiles.Bosses.Dirtball.LaserMineHostileFall>();
					if (attackInt % 2 == 0) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-7, 8), Main.rand.NextFloat(-9, -7)), proj, (int)(NPC.damage * 0.2f), 0f, BasicNetType: 2);
                }
				else {
					attackTimer++;
					if (attackTimer > 120) attackDone = true;
                }
            }
			else if (attack == 2) { //MOVEMENT X = normal movement, but only x part
				if (attackInt < 2) {
					movement = false;
					NPC.velocity *= 0.98f;
					attackTimer++;
					if (attackTimer < 60) return;
				}
				if (attackInt == 0) {
					NPC.velocity.X *= 0.98f;
					if (Timer % 3 == 0)
						NPC.velocity.Y -= 1;
					if (NPC.velocity.Y < -8) NPC.velocity.Y = -8;

					if (NPC.Center.Y < Main.player[NPC.target].Center.Y-400)
						attackInt = 1;
				}
				if (attackInt == 1) {
					NPC.velocity.X *= 0.98f;
					NPC.velocity.Y += 1;
					NPC.rotation += 0.1f;
					if (NPC.velocity.Y > 12) NPC.velocity.Y = 12;
					if (NPC.Center.Y > Main.player[NPC.target].Center.Y)
						attackInt = 2;
					if (Timer % (15 + (int)(15*NPC.life/NPC.lifeMax)) == 0) {
						if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(10, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage * 0.25f), 0f, BasicNetType: 2);
						else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(7, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>(), (int)(NPC.damage * 0.2f), 0f, BasicNetType: 2);
						if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(-10, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage * 0.25f), 0f, BasicNetType: 2);
						else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(-7, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>(), (int)(NPC.damage * 0.2f), 0f, BasicNetType: 2);
					}
                }
				if (attackInt == 2) {
					attackTimer++;
					NPC.noTileCollide = false;
					NPC.velocity.Y += 1;
					NPC.rotation += 0.1f;
					if (NPC.velocity.Y > 10) NPC.velocity.Y = 10;
					if (Timer % (15 + (int)(15*NPC.life/NPC.lifeMax)) == 0) {
						if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(10, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage * 0.25f), 0f, BasicNetType: 2);
						else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(7, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>(), (int)(NPC.damage * 0.2f), 0f, BasicNetType: 2);
						if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(-10, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>(), (int)(NPC.damage * 0.25f), 0f, BasicNetType:2);
						else ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(-7, 0), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>(), (int)(NPC.damage * 0.2f), 0f, BasicNetType: 2);
					}
					if (NPC.velocity.Y == 1 && attackBool == false) {
						attackBool = true;
                    }
					else if (attackBool && NPC.velocity.Y == 1) {
						NPC.noTileCollide = true;
						NPC.velocity.Y = 0;
						attackTimer = 0;
						attackInt = 3;
						for (int i = 0; i < 24; i++)
							SoundEngine.PlaySound(SoundID.Dig, NPC.Center + new Vector2(Main.rand.Next(-50, 51), Main.rand.Next(-50, 51)));
						int consV = 16 - (int)(8*NPC.life/NPC.lifeMax);
						for (int i = 0; i < consV; i++) {
							int proj = ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtGlobHostile>();
							int speed = 8;
							float dam = 0.2f;
							if (phase == 3 || (phase == 2 && Main.rand.NextBool(2))) {
								speed = 10;
								proj = ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtballLaser>();
								dam = 0.25f;
							}
							ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, speed).RotatedBy(2*Math.PI/consV*i), proj, (int)(NPC.damage*dam), 0f, BasicNetType: 2);
						}
					}
                }
				if (attackInt == 3) {
					attackTimer++;
					movement = true;
					if (attackTimer > 60 + (int)(30*NPC.life/NPC.lifeMax))
						attackDone = true;
                }
			}
			else if (attack == 3 || attack == 4) {
				movement = true;
				attackTimer++;
				if (speedBoost < 5f)
					speedBoost *= 2.5f;
				if (attackTimer > 120 + (int)(60*NPC.life/NPC.lifeMax))
					attackDone = true;
            }
			else if (attack == 5) {
				attackTimer++;
				if (attackTimer == 1)
					if (phase == 3 || (phase == 2 && Main.rand.NextBool(2)))
						attackInt = 1;
					else attackInt = 0;
				if (attackInt == 0) {
					//movement = false;
					NPC.velocity *= 0.95f;
					NPC.rotation += 0.1f;
					for (int i = 0; i < 3 - phase; i++) {
						int dustIndex = Dust.NewDust(NPC.Center - new Vector2(4, 0), 1, 1, DustID.Dirt);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Vector2(0, 6).RotatedByRandom(2*Math.PI);
						if (dust.velocity.Y > 0 && phase == 2) dust.velocity.Y *= -1;
						dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
					}
					if (phase == 2) for (int i = 0; i < 1; i++) {
						int dustIndex = Dust.NewDust(NPC.Center - new Vector2(4, 0), 1, 1, DustID.Electric);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Vector2(0, 6).RotatedByRandom(2*Math.PI);
						if (dust.velocity.Y < 0) dust.velocity.Y *= -1;
						dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
					}
					if (attackTimer % 10 == 1) {
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DirtBlock>());
						SoundEngine.PlaySound(SoundID.Dig, NPC.Center);
					}

					if (attackTimer == 101) {
						attackDone = true;
						movement = true;
					}
				}
				else if (attackInt == 1) {
					//movement = false;
					NPC.velocity *= 0.96f;
					for (int i = 0; i < phase - 1; i++) {
						int dustIndex = Dust.NewDust(NPC.Center - new Vector2(4, 0), 1, 1, DustID.Electric);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Vector2(0, 6).RotatedByRandom(2*Math.PI);
						if (dust.velocity.Y < 0 && phase == 2) dust.velocity.Y *= -1;
						dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
					}
					if (phase == 2) for (int i = 0; i < 1; i++) {
						int dustIndex = Dust.NewDust(NPC.Center - new Vector2(4, 0), 1, 1, DustID.Dirt);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Vector2(0, 6).RotatedByRandom(2*Math.PI);
						if (dust.velocity.Y > 0) dust.velocity.Y *= -1;
						dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
					}
					if (attackTimer % 40 == 1) {
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DS_17>());
						SoundEngine.PlaySound(SoundID.Item93, NPC.Center);
					}
					if (attackTimer == 81 || NPC.CountNPCS(ModContent.NPCType<DS_17>()) > 4) {
						attackDone = true;
						movement = true;
					}
                }
            }
			/*else if (attack == 5) { //scrapped ver
				attackTimer++;
				if (attackTimer == 1)
					attackInt = (int)(50 + (20*NPC.life/NPC.lifeMax));
				if (attackTimer % attackInt < attackInt - 10) {
					movement = false;
					NPC.velocity *= 0.97f;
                }
				else movement = true;
				if (attackTimer % attackInt == 0) {
					if ((phase > 2 && attackTimer == attackInt) || (phase > 1 && attackTimer > attackInt)) {

                    }
					else {

                    }
                }
				if (attackTimer == (attackInt*3)-1)
					attackDone = true;
            }*/
			//if (attack == 1 && (attackTimer > (60 + (int)(30*NPC.life/NPC.lifeMax))) || attackTimer > 0) speedBoost *= 0.75f;
			//Main.NewText(attack);
			if (!(attack == 2 && (attackInt == 1 || attackInt == 2))) NPC.rotation = NPC.velocity.X*0.02f;
			if (!movement) return;
							if (NPC.direction == -1 && NPC.velocity.X > -4f*speedBoost)
							{
								NPC.velocity.X = NPC.velocity.X - 0.1f*speedBoost;
								if (NPC.velocity.X > 4f*speedBoost)
								{
									NPC.velocity.X = NPC.velocity.X - 0.1f*speedBoost;
								}
								else if (NPC.velocity.X > 0f)
								{
									NPC.velocity.X = NPC.velocity.X + 0.05f*speedBoost;
								}
								if (NPC.velocity.X < -4f*speedBoost)
								{
									NPC.velocity.X = -4f*speedBoost;
								}
							}
							else if (NPC.direction == 1 && NPC.velocity.X < 4f*speedBoost)
							{
								NPC.velocity.X = NPC.velocity.X + 0.1f*speedBoost;
								if (NPC.velocity.X < -4f*speedBoost)
								{
									NPC.velocity.X = NPC.velocity.X + 0.1f*speedBoost;
								}
								else if (NPC.velocity.X < 0f)
								{
									NPC.velocity.X = NPC.velocity.X - 0.05f*speedBoost;
								}
								if (NPC.velocity.X > 4f*speedBoost)
								{
									NPC.velocity.X = 4f*speedBoost;
								}
							}
			//if (NPC.velocity.X > 4*speedBoost) NPC.velocity.X = 4*(int)speedBoost;
			//if (NPC.velocity.X < -4*speedBoost) NPC.velocity.X = -4*(int)speedBoost;
							/*if (NPC.directionY == -1 && (double)NPC.velocity.Y > -1.5*speedBoost)
							{
								NPC.velocity.Y = NPC.velocity.Y - 0.04f*speedBoost;
								if ((double)NPC.velocity.Y > 1.5*speedBoost)
								{
									NPC.velocity.Y = NPC.velocity.Y - 0.05f*speedBoost;
								}
								else if (NPC.velocity.Y > 0f*speedBoost)
								{
									NPC.velocity.Y = NPC.velocity.Y + 0.03f*speedBoost;
								}
								if ((double)NPC.velocity.Y < -1.5*speedBoost)
								{
									NPC.velocity.Y = -1.5f*speedBoost;
								}
							}
							else if (NPC.directionY == 1 && (double)NPC.velocity.Y < 1.5*speedBoost)
							{
								NPC.velocity.Y = NPC.velocity.Y + 0.04f*speedBoost;
								if ((double)NPC.velocity.Y < -1.5*speedBoost)
								{
									NPC.velocity.Y = NPC.velocity.Y + 0.05f*speedBoost;
								}
								else if (NPC.velocity.Y < 0f*speedBoost)
								{
									NPC.velocity.Y = NPC.velocity.Y - 0.03f*speedBoost;
								}
								if ((double)NPC.velocity.Y > 1.5*speedBoost)
								{
									NPC.velocity.Y = 1.5f*speedBoost;
								}
							}*/
						
						NPC.ai[1] += 1f;
						if (NPC.ai[1] > 200f)
						{
							if (!Main.player[NPC.target].wet && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
							{
								NPC.ai[1] = 0f;
							}
							float num209 = 0.2f;
							float num210 = 0.1f;
							float num211 = 4f;
							float num212 = 1.5f;
							if (NPC.ai[1] > 1000f)
							{
								NPC.ai[1] = 0f;
							}
							NPC.ai[2] += 1f;
							if (NPC.ai[2] > 0f)
							{
								if (NPC.velocity.Y < num212)
								{
									NPC.velocity.Y = NPC.velocity.Y + num210;
								}
							}
							else if (NPC.velocity.Y > -num212)
							{
								NPC.velocity.Y = NPC.velocity.Y - num210;
							}
							if (NPC.ai[2] < -150f || NPC.ai[2] > 150f)
							{
								if (NPC.velocity.X < num211)
								{
									NPC.velocity.X = NPC.velocity.X + num209;
								}
							}
							else if (NPC.velocity.X > -num211)
							{
								NPC.velocity.X = NPC.velocity.X - num209;
							}
							if (NPC.ai[2] > 300f)
							{
								NPC.ai[2] = -300f;
							}
						}
			if (NPC.Center.Y + 50 > Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel -= 1;
			if (NPC.Center.Y - 50 < Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel += 1;
			if (yvel > 8) yvel = 8;
			if (yvel < -8) yvel = -8;
			if (yvel > 0 && NPC.Center.Y > Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel -= 1;
			if (yvel < 0 && NPC.Center.Y < Main.player[NPC.target].Center.Y && Timer % 12 == 0) yvel += 1;
			NPC.velocity.Y = yvel; //if (Math.Abs(NPC.Center.Y - Main.player[NPC.target].Center.Y) > 80) NPC.velocity.Y = yvel;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("An ancient failed drone possessed by a playful forest spirit.")
			});
		}
		public override void BossLoot(ref string name, ref int potionType) {
			ZylonWorldCheckSystem.downedDirtball = true;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (Main.masterMode) {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Relics.DirtballRelic>(), 1));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.DS_91Controller>(), 4));
            }
			if (Main.expertMode || Main.masterMode) npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bags.DirtballBag>(), 1));
			else {
				npcLoot.Add(new CommonDrop(ItemID.DirtBlock, 1, 25, 50));
				npcLoot.Add(new CommonDrop(ItemID.MudBlock, 1, 15, 30));
				npcLoot.Add(new CommonDrop(ItemID.IronBar, 1, 1, 3));
				npcLoot.Add(new CommonDrop(ItemID.LeadBar, 1, 1, 3));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bars.ZincBar>(), 1, 1, 3));
				npcLoot.Add(new CommonDrop(ItemID.DirtRod, 5));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Misc.Dirtthrower>(), 25));
				npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.MuddyGreatsword>(), ModContent.ItemType<Items.Yoyos.Dirtglob>(), ModContent.ItemType<Items.Bows.Dirty3String>(), ModContent.ItemType<Items.Blowpipes.DirtFunnel>(), ModContent.ItemType<Items.Wands.ScepterofDirt>(), ModContent.ItemType<Items.Accessories.DirtRegalia>()));
				npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.OvergrownHilt>(), ModContent.ItemType<Items.Guns.OvergrownHandgunFragment>(), ModContent.ItemType<Items.MagicGuns.OvergrownElectricalComponent>()));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.DirtballMask>(), 7));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.CreepyBlob>(), 10));
            }
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.DirtballTrophy>(), 10));
		}
    }
}