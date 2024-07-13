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

namespace Zylon.NPCs.Bosses.Adeneb
{
	[AutoloadBossHead]
    public class Adeneb : ModNPC
	{
        public override void SetStaticDefaults() {
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Chilled] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frozen] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Burning] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Frostburn] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/Bosses/Adeneb/Adeneb_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
        }
        public override void SetDefaults() {
            NPC.width = 48;
			NPC.height = 48;
			NPC.damage = 33;
			NPC.defense = 18;
			NPC.lifeMax = (int)(4000*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = 60000;
			NPC.aiStyle = -1; //14
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			//Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DirtStep");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
			NPC.lifeMax = (int)(5200*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 61;
			NPC.value = 140000;
			if (Main.masterMode) {
				NPC.lifeMax = (int)(6400*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 94;
            }
        }
        public override void HitEffect(NPC.HitInfo hit) {
            if (NPC.life < 1 && !finale) { //&& (Main.expertMode || Main.masterMode)
				//NPC.immortal = true;
				NPC.life = 1;
				NPC.dontTakeDamage = true;
				finale = true;
				EndAttack();
            }
        }
        int attack;
		int attackTimer;
		int attackTimer2;
		int attackInt;
		int prevAttack;
		float attackFloat;
		float attackFloatFinale;
		float o;
		bool attackDone = true;
		bool introAttackDone;
		int phase = 1;
		int angerTimer;
		int flee;
		bool transitionSetup;
		bool drawAura; //Determines if it should burn the player
		bool finale;
		int arenaTimer;
		//bool adenebTurn = true;
		Vector2 dashVelocity;
		Vector2 tempVector;
		Vector2 newVel;
		Vector2 finaleSave;
		Player target;
        public override void AI() {
			NPC.ai[0] = phase;

			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.adenebBoss = NPC.whoAmI;

			//enrage + stat manager code
			NPC.damage = 33;
			NPC.defense = 18;
			if (Main.expertMode) { NPC.damage = 61; }
			if (Main.masterMode) { NPC.damage = 92; }

			if (phase == 2) {
				NPC.damage = 45;
				NPC.defense = 8;
				if (Main.expertMode) { NPC.damage = 75; }
				if (Main.masterMode) { NPC.damage = 109; }
				/*if (Main.getGoodWorld) { //For the Worthy: While hands are attacking, gains lots of defense and becomes semi-invisible
					if (NPC.ai[0] == 1f) {
						NPC.alpha = 127;
						NPC.defense = 36;
                    }
					else {
						NPC.alpha = 0;
						NPC.defense = 12;
                    }
                }*/
            }
			//NPC.damage = (int)(NPC.damage*(1.2f-(0.2f*NPC.life/NPC.lifeMax)));

			if (!target.ZoneDesert && !target.ZoneUndergroundDesert && !(phase == 1 && NPC.life <= NPC.lifeMax/2) && !finale) {
				angerTimer++;
			}
			else angerTimer = 0;
			if (angerTimer > 240) {
				NPC.damage = (int)(NPC.damage*1.5f);
				NPC.defense = 36;
            }

			if (Main.getGoodWorld) NPC.damage = (int)(NPC.damage*1.33f);

			//flee code
			if (Main.player[NPC.target].statLife < 1 && !finale) { //If he despawned during the finale that would be so hilariously sad
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					//if (flee == 0)
					flee++;
				}
				else if ((finale || (phase == 1 && NPC.life <= NPC.lifeMax/2)) && Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 1700) {
					flee++;
                }
				else
				flee = 0;
				if (flee > 0) {
					if (flee == 1) newVel = Vector2.Zero;
					if (flee % 10 == 0)
					newVel.Y += 1;
					NPC.velocity = newVel;
					if (phase == 1 && NPC.life <= NPC.lifeMax/2) NPC.velocity = Vector2.Zero;
					if (flee > 300) NPC.active = false;
					if (flee > 30 && ((phase == 1 && NPC.life <= NPC.lifeMax/2) || finale)) NPC.active = false;
					return;
				}
			}

			if (finale) {
				NPC.ai[0] = 3; //signals suns to despawn
				attackTimer++;
				if (attackTimer < 30) NPC.velocity *= 0.9f;
				else if (attackTimer == 30) NPC.velocity = Vector2.Zero;

				if (attackTimer >= 60) OrbDrawRotation += 0.001f*(attackTimer-60);
				if (attackTimer == 120) {
					NPC.velocity = NPC.Center - Main.player[NPC.target].Center;
					NPC.velocity.Normalize();
					NPC.velocity *= -0.05f;
					finaleSave = Main.player[NPC.target].Center;
				}
				if (attackTimer > 120) {
					NPC.velocity *= 1.05f;

					if ((NPC.Center.Y < finaleSave.Y && NPC.velocity.Y < 0) || (NPC.Center.Y > finaleSave.Y && NPC.velocity.Y > 0)) {
						NPC.immortal = false;
						NPC.dontTakeDamage = false;
						//NPC.life = 1;
						//Main.player[NPC.target].ApplyDamageToNPC(NPC, 1, 0f, 0);
						if (Main.netMode != NetmodeID.MultiplayerClient) NPC.StrikeInstantKill();

						//DIE!
						for (int i = 0; i < 32; i++) {
							int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.SolarFlare);
							Dust dust = Main.dust[dustIndex];
							dust.velocity = new Vector2(0, Main.rand.NextFloat(3f, 7f)).RotatedByRandom(MathHelper.TwoPi);
							dust.scale *= 1.5f + Main.rand.Next(-80, 81) * 0.01f;
						}
						for (int i = 0; i < 3; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-1, 6)), ModContent.GoreType<Gores.Bosses.Adeneb.AdenebDead1>());
						Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-1, 6)), ModContent.GoreType<Gores.Bosses.Adeneb.AdenebDead2>());
						Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-1, 6)), ModContent.GoreType<Gores.Bosses.Adeneb.AdenebDead3>());
					}
				}
				return;
            }

			if (phase == 1 && NPC.life <= NPC.lifeMax/2) {
				NPC.dontTakeDamage = true;
				if (!transitionSetup) { //probably screwed up some attack by cutting it off btw
					attackDone = false;
					attackTimer = 0;
					attackTimer2 = 0;
					attackFloat = 0f;
					attackInt = 0;
					transitionSetup = true;

					if (!Main.expertMode) attackTimer = 2199;
                }
				attackTimer++;
				if (attackTimer < 30) { //slowdown transition pt 1
					NPC.velocity *= 0.8f;
				}
				else if (attackTimer < 60) { //slowdown transition pt 2
					attackFloat += 0.25f;
				}
				else if (attackTimer < 150) { //positioning
					if (attackTimer % 3 == 0) {
						if (NPC.Center.Y > target.Center.Y) NPC.velocity.Y -= 1;
						else if (NPC.Center.Y < target.Center.Y - 144) NPC.velocity.Y += 1;
						else NPC.velocity.Y *= 0.8f;
						if (NPC.Center.X < target.Center.X - 300) NPC.velocity.X += 1;
						else if (NPC.Center.X > target.Center.X + 300) NPC.velocity.X -= 1;
						else NPC.velocity.X *= 0.8f;
					}
					if (attackTimer == 149) tempVector = NPC.Center;
                }
				else if (attackTimer < 400) { //gather the players
					NPC.velocity = Vector2.Zero;
					if (attackTimer % 10 == 0) {
						//start at 150, end at 400
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), tempVector - new Vector2(1200-((attackTimer-150)*4), 750), new Vector2(0, 20), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4+5, 0f, Main.myPlayer);
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), tempVector + new Vector2(1200-((attackTimer-150)*4), -750), new Vector2(0, 20), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4+5, 0f, Main.myPlayer);
						//if (attackTimer)
					}
					if (attackTimer == 399) {
						drawAura = true; //Feel free to change any variable stuff idrc, just doing the bare minimum to show the general idea
                    }
                } //No attack buff when out biome in phase transition
				else if (attackTimer < 520) {
					//insert aura creation animation if you want, otherwise remove this grace period
                }
				else if (attackTimer < 900) { //Transition part 1
					if (attackTimer % 3 == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, -800).RotatedBy(MathHelper.ToRadians((attackTimer-520)*2)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage/4+1, 0f, Main.myPlayer);
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 800).RotatedBy(MathHelper.ToRadians((attackTimer-520)*2)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage/4+1, 0f, Main.myPlayer);
                    }
                }
				else if (attackTimer < 1200) { //Transition part 2
					if (attackTimer % 6 == 0 && attackTimer > 960 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, -800).RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage/3, 0f, Main.myPlayer, 0.25f);   
                }
				else if (attackTimer < 1621) {//Transition part 3
					float rand = Main.rand.NextFloat(0, 45);
					if (attackTimer % 120 == 60 && Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < 8; x++) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 800), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSun>(), NPC.damage/3+2, 0f, Main.myPlayer, x*45+rand);
                    }
				}
				else if (attackTimer < 2201) { //End of transition
					if (attackTimer == 1800 && Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < 8; x++) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 800), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSunBig>(), NPC.damage/3+4, 0f, Main.myPlayer, x*45);
                    }
					if (attackTimer == 2200) {
						//END OF TRANSITION phase, drawaura
						drawAura = false;
						float rand = 1f;
						if (Main.rand.NextBool()) rand = -1f;
						Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center - new Vector2(66, 121), new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-9, -7)), ModContent.GoreType<Gores.Bosses.Adeneb.Adeneb_Ankh>());
						Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-6, -2)*rand, Main.rand.NextFloat(-1, 3)), ModContent.GoreType<Gores.Bosses.Adeneb.Adeneb_SpikeLower>());
						Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(2, 6)*rand, Main.rand.NextFloat(-1, 3)), ModContent.GoreType<Gores.Bosses.Adeneb.Adeneb_SpikeUpper>());
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebSunShield>(), NPC.damage/3, 0f);
                    }
                }
				else {
					if (!Main.expertMode) NPC.velocity *= 0.95f;
					if (attackTimer == 2320) {
						//again change the length of this to fit anim
						phase = 2;
						prevAttack = -1;
						EndAttack();
						NPC.dontTakeDamage = false;
						NPC.rotation = 0f;
					}
                }

				//Animate the arena
				if (attackTimer > 369) arenaTimer++;

				//REMOVE THIS THIS IS JUST FOR SKIPPING THE TRANSIIOTN 4 TESTING!!!!!!!!!!!!!!!!!!!
				//if (attackTimer < 2200) attackTimer = 2199;

				/*phase = 2;
				prevAttack = -1;
				EndAttack();
				NPC.dontTakeDamage = false;
				NPC.rotation = 0f;*/
				//REMOVE THIS THIS IS JUST FOR SKIPPING THE TRANSIIOTN 4 TESTING!!!!!!!!!!!!!!!!!!!


				NPC.rotation += MathHelper.ToRadians(attackFloat); //Do whatever you want for the visuals, remove this part if you want. This is just a placeholder since I am not the wacky visual man.
				SpikeGlobalDrawRotation = NPC.rotation;
				OrbDrawRotation = -NPC.rotation;

				if (drawAura) {
					for (int x = 0; x < Main.maxPlayers; x++) {
						float dist = Vector2.Distance(NPC.Center, Main.player[x].Center);
						if (dist > 500 && dist < 3000) Main.player[x].AddBuff(ModContent.BuffType<Buffs.Debuffs.SearedFlame>(), 2);
                    }
                }

				return;
			}

			if (attackDone) { //dash
				if (introAttackDone || phase == 2) {
					if (phase == 2) {
						if (Main.getGoodWorld) NPC.scale = 1.5f;

						attack = Main.rand.Next(3);
						while (prevAttack == attack) attack = Main.rand.Next(3);
                    }
					else {
						attack = Main.rand.Next(3);
						while (prevAttack == attack) attack = Main.rand.Next(3);
                    }
					//attack = 3; //Use this to set attacks to specific ones.

					attackDone = false;
					attackTimer = 0;
					attackTimer2 = 0;
					attackFloat = 0f;
					attackInt = 0;
					prevAttack = attack;
                }
				else {
					attackTimer++;
					if (attackTimer == 1) {
						float h = -60f;
						dashVelocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * h;
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center+dashVelocity, dashVelocity, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPremonition>(), 0, 0, Main.myPlayer, 20);
	                }
					if (attackTimer < 10) {
						NPC.velocity /= 2;
	                }
					if (attackTimer == 60) {
						dashVelocity.Normalize();
						NPC.velocity = dashVelocity*24f;
						o = 0.1f;
						if (Main.expertMode) o += 0.025f;
					}
					if (attackTimer > 60) {
						NPC.velocity *= 0.965f; //0.96
						o *= 0.978f; //0.97
						NPC.rotation += o*3f;//*(0.1f+(0.015f*120-attackTimer));
					}
	
					if (attackTimer >= 200) { //ATTACK SETUP
						attack = Main.rand.Next(3);
						attackDone = false;
						attackTimer = 0;
						attackTimer2 = 0;
						attackFloat = 0f;
						attackInt = 0;
						introAttackDone = true;
						prevAttack = attack;
					}
				}
            }
			else { //See tome man? I'm doing a thing!
				if (phase == 1) switch (attack) {
					case 0:
						SpinLaser();
						break;
					case 1:
						ScaryChase();
						break;
					case 2:
						BigSun(); //MineRing();
						break;
                }
				else switch (attack) { //else if (NPC.ai[0] == 0f) switch (attack) {
					case 0:
						ShieldSplit();
						break;
					case 1:
						SunRayRing();
						break;
					case 2:
						MiniSunBarrage();
						break;
					case 3:
						FourthAttack();
						break;
                }
				//else Phase2Move();
            }
			SpikeGlobalDrawRotation = NPC.rotation;
			OrbDrawRotation = -NPC.rotation;
        }
		float w = 1f;
		private void SpinLaser() {
			attackTimer++;
			if (attackTimer <= 11) {
				w = 1.2f-(0.2f*NPC.life/(NPC.lifeMax/2)); //sets turn speed
				if (w > 1.2f) w = 1.2f;
				NPC.velocity /= 2;
			}
			else {
				if (Vector2.Distance(NPC.Center, target.Center) > 800) { //checks if player is a dirty cheater lmbo
					attackTimer2--;
					if (attackTimer2 < 0) {
						NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center)*-15f;
						attackTimer2 = 10;
					}
				}
				else if (Vector2.Distance(NPC.Center, target.Center) < 600) NPC.velocity *= 0.6f; //slows down boss
			}
			//NPC.velocity /= 2;
			if (attackTimer > 10 && attackTimer < 670) { //main
				//float ooh = -0.00016f*(attackTimer*attackTimer) + 0.0832f*(attackTimer) - 0.816f;
				
				if (attackTimer < 340) attackFloat += 0.0006f*w;
				else attackFloat -= 0.0006f*w;
				NPC.rotation += attackFloat;

				int x = (int)(6+(7*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2))); //og = 4 + 5 = 9
				if (x > 13) x = 13;

				if (attackTimer % x == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4, 0f);
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, 10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4, 0f);
                }
            }
			else if (attackTimer > 670) EndAttack(); //Ends attack
        }
		private void ScaryChase() { //This was originally GerdSuggest but I got another idea and it transformed
			attackTimer++;
			RotateTowardsPlayer();

			//Vertical manager
			if (NPC.Center.Y < target.Center.Y - 100 && attackTimer % 3 == 0) NPC.velocity.Y += 1;
			else if (NPC.Center.Y > target.Center.Y + 100 && attackTimer % 3 == 0) NPC.velocity.Y -= 1;
			if (NPC.velocity.Y > 6) NPC.velocity.Y = 6;
			if (NPC.velocity.Y < -6) NPC.velocity.Y = -6;

			//Horizontal manager
			int babyMode = 50;
			int car = (int)(50-(50*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)));
			if (car < 0) car = 0;
			if (Main.expertMode) babyMode = 0;
			if (NPC.Center.X < target.Center.X - 350 - babyMode + car) NPC.velocity.X = 10;
			if (NPC.Center.X > target.Center.X + 350 + babyMode - car) NPC.velocity.X = -10;
			NPC.velocity.X *= 0.98f;

			//ATTACK
			int x = (int)(70+(40*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2))); //og 60 + 20 = 80
			if (x > 110) x = 110;
			if (attackTimer >= x) {
				attackTimer = 0;
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, 10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebXBeam>(), NPC.damage/4+2, 0f);
				attackTimer2++;
			}

			if (attackTimer2 > 9) EndAttack();
        }
		private void BigSun() {
			//NPC.velocity /= 2;
			attackFloat = 4.5f-(int)(2f*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2));
			if (attackFloat < 2.5f) attackFloat = 2.5f;
			NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * (float)(-1*attackFloat);

			RotateTowardsPlayer();
			attackTimer++;
			if (attackTimer == 1 && attackTimer2 == 0) {
				attackInt = 6-(int)(4*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2));
				if (attackInt < 2) attackInt = 2;
            }
			int x = (int)(60*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)); //og 60 to 0
			if (x < 0) x = 0;
			if (attackTimer >= x) {
				attackTimer = -180; //og -120
				if (!Main.expertMode) attackTimer -= 30;
				if (attackTimer2 <= attackInt) if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun>(), NPC.damage/4+4, 0f);
				attackTimer2++;
				if (attackTimer2 > attackInt + 1) EndAttack();
            }
        }
		private void Phase2Move() {
			attackTimer++;
			RotateTowardsPlayer();

			float c = 1f;
			if (Main.getGoodWorld) c = 1.3f;

			//Vertical manager
			if (NPC.Center.Y < target.Center.Y && attackTimer % 5 == 0) NPC.velocity.Y += c;
			else if (attackTimer % 5 == 0) NPC.velocity.Y -= c;
			if (NPC.velocity.Y > 13) NPC.velocity.Y = 13;
			if (NPC.velocity.Y < -13) NPC.velocity.Y = -13;

			//Horizontal manager
			if (NPC.Center.X < target.Center.X && attackTimer % 5 == 0) NPC.velocity.X += c;
			else if (attackTimer % 5 == 0) NPC.velocity.X -= c;
			if (NPC.velocity.X > 13) NPC.velocity.X = 13;
			if (NPC.velocity.X < -13) NPC.velocity.X = -13;
        }

		private void Phase2Move2() { //Like previous but more aggressive horizontally
			attackTimer++;
			RotateTowardsPlayer();

			float c = 1.25f;
			if (Main.getGoodWorld) c = 1.5f;

			//Vertical manager
			if (NPC.Center.Y < target.Center.Y && attackTimer % 5 == 0) NPC.velocity.Y += c;
			else if (attackTimer % 5 == 0) NPC.velocity.Y -= c;
			if (NPC.velocity.Y > 10) NPC.velocity.Y = 10;
			if (NPC.velocity.Y < -10) NPC.velocity.Y = -10;

			//Horizontal manager
			if (NPC.Center.X < target.Center.X && attackTimer % 5 == 0) NPC.velocity.X += c;
			else if (attackTimer % 5 == 0) NPC.velocity.X -= c;
			if (NPC.velocity.X > 20) NPC.velocity.X = 20;
			if (NPC.velocity.X < -20) NPC.velocity.X = -20;

			if (NPC.Center.X < target.Center.X - 800) NPC.velocity.X += 2;
			if (NPC.Center.X > target.Center.X + 800) NPC.velocity.X -= 2;
        }

		float dashPower;
		float hpLeft2;
		private void ShieldSplit() {
			NPC.ai[1] = 1;
			attackTimer++;

			if (attackFloat == 0f) {
				NPC.velocity *= 0.9f;
				if (attackTimer >= 50) {
					attackTimer = 0;
					attackFloat = 1f;
                }
            }
			else if (attackFloat < 5f) {
				if (attackTimer == 1) {
					hpLeft2 = (float)NPC.life/(float)(NPC.lifeMax/2);
					float h = -60f;
					dashVelocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * h;
					dashPower = Math.Abs(Vector2.Distance(NPC.Center, Main.player[NPC.target].Center));
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center+dashVelocity, dashVelocity, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPremonition>(), 0, 0, Main.myPlayer, 20);
				}
				if (attackTimer < 10) {
					NPC.velocity /= 2;
	            }
				if (attackTimer == 30) {
					dashVelocity.Normalize();
					if (Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 450f) NPC.velocity = dashVelocity*dashPower*(0.075f - (0.015f*hpLeft2));//0.04f is reach pos;
					else {
						NPC.velocity = dashVelocity*(36f - (9f*hpLeft2));
                    }
					o = 0.1f;
					if (Main.expertMode) o += 0.025f;
				}
				if (attackTimer > 30) {
					NPC.velocity *= 0.965f; //0.96
					o *= 0.978f; //0.97
					NPC.rotation += o*3f;//*(0.1f+(0.015f*120-attackTimer));
				}
	
				if (attackTimer >= 90) { //ATTACK SETUP
					//if (attackFloat >= 3) EndAttack();
					attackTimer = 0; //else attackTimer = 0;
					attackFloat += 1f;
				}
            }
			else {
				NPC.ai[1] = 0f;
				Phase2Move(); //attackTimer is incremented twice now but who cares
				if (attackTimer >= 180) EndAttack();
            }
        }
		private void SunRayRing() {
			Phase2Move2();
			hpLeft2 = (float)NPC.life/(float)(NPC.lifeMax/2);
			if (attackTimer >= (90 + (15*hpLeft2))) { NPC.ai[1] = 2; attackTimer = 0; attackTimer2++; }
			else NPC.ai[1] = 0;

			//if (attackTimer % 30 == 0) Main.NewText(hpLeft2); //TESTING

			if (attackTimer2 > 6 - (3*hpLeft2)) EndAttack();
        }
		private void MiniSunBarrage() {
			Phase2Move2();
			hpLeft2 = (float)NPC.life/(float)(NPC.lifeMax/2);
			if (attackTimer == 1) NPC.ai[1] = 3;
			else NPC.ai[1] = 0;
			if (attackTimer > 420) EndAttack();
        }
		private void FourthAttack() { //Ominous name, huh? I'm making this up as I go so idk what to call it.
			Phase2Move();
			if (attackTimer == 1) NPC.ai[1] = 4;
			if (attackTimer > 480) EndAttack();
		}

		float degrees;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		float angle = 0.5f * (float)Math.PI;
		bool whatDir;
		bool start;
		private void RotateTowardsPlayer() { //Taken from desert diskite eye code

			if (!start) {
				degrees = MathHelper.ToDegrees(NPC.rotation); //ALWAYS RESET START AFTER ENDING RTP
				start = true;
            }

			Vector2 look = target.Center - NPC.Center;
			angle = 0.5f * (float)Math.PI;
			if (look.X != 0f) {
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f) {
				angle += (float)Math.PI;
			}
			if (look.X < 0f) {
				angle += (float)Math.PI;
			}

			targetRot = angle;
			//targetRot += MathHelper.ToRadians(90);

			targetRot += MathHelper.ToRadians(90);
			//if (look.X > 0) targetRot += MathHelper.ToRadians(90);
			//else targetRot += MathHelper.ToRadians(270);

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (degTemp < targTemp) degTemp += 360;
			count1 = degTemp - targTemp;

			degTemp = degrees;
			targTemp = MathHelper.ToDegrees(targetRot);
			if (targTemp < degTemp) targTemp += 360;
			count2 = targTemp - degTemp;

			whatDir = count1 >= count2;

			//if (whatDir) degrees += 1.5f;
			//else degrees -= 1.5f;
			
			if (whatDir) degSpeed += 0.5f;
			else degSpeed -= 0.5f;

			if (degSpeed > 2.5f && !Main.expertMode) degSpeed = 3f;
			else if (degSpeed > 3.5f && Main.expertMode) degSpeed = 4f;
			if (degSpeed < -2.5f && !Main.expertMode) degSpeed = -3f;
			else if (degSpeed < -3.5f && Main.expertMode) degSpeed = -4f;

			//if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 1f)
			//	degSpeed = Math.Abs(degrees - MathHelper.ToDegrees(targetRot));

			degrees += degSpeed;

			if (Math.Abs(degrees - MathHelper.ToDegrees(targetRot)) < 2f && degSpeed <= 2f) {
				degrees = MathHelper.ToDegrees(targetRot);
				degSpeed = 0;
            }

			if (degrees < 0) degrees = 360;
			if (degrees > 360) degrees = 0;

			//NPC.Center = main.Center - new Vector2(0, 8).RotatedBy(MathHelper.ToRadians(degrees)); //16 for normal
			NPC.rotation = MathHelper.ToRadians(degrees);
        }
		private void EndAttack() {
			attack = -1;
			attackTimer = 0;
			attackTimer2 = 0;
			attackDone = true;
			attackFloat = 0f;
			attackInt = 0;
			start = false;
			//NPC.ai[0] = 1f; //REMOVE
			NPC.ai[1] = 0f;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A forgotten civilization's adopted protector, powered by a computer chip blessed by the sun god.")
			});
		}

		float OrbDrawRotation = 0f;
		float SpikeGlobalDrawRotation = 0f;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D spikeTextureTop = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_SpikeUpper");
			Texture2D spikeTextureBottom = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_SpikeLower");
			Texture2D ankhTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Ankh");
			//Texture2D auraTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Aura");
			Texture2D deathTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Death");

			Texture2D orangeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_ArenaOrange");
			Texture2D yellowTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_ArenaYellow");

			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

			Vector2 spikeOrigin = spikeTextureTop.Size() * 0.5f;
			Vector2 ankhOrigin = ankhTexture.Size() * 0.5f;
			Vector2 arenaOrigin = ankhTexture.Size() * 0.5f;

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = NPC.GetAlpha(drawColor);
			var effects = SpriteEffects.None;

			bool cond = phase == 1 && !(NPC.life <= NPC.lifeMax/2 && attackTimer >= 2200);

			if (cond) spriteBatch.Draw(spikeTextureBottom, drawPos + new Vector2(0, 80).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, spikeOrigin, NPC.scale, effects, 0);
			spriteBatch.Draw(texture, drawPos, null, color, OrbDrawRotation, drawOrigin, NPC.scale, effects, 0);
			if (cond) spriteBatch.Draw(spikeTextureTop, drawPos + new Vector2(0, -80).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, spikeOrigin, NPC.scale, effects, 0);
			if (cond) spriteBatch.Draw(ankhTexture, drawPos + new Vector2(0, -20).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, ankhOrigin, NPC.scale, effects, 0);

			//if (drawAura) spriteBatch.Draw(auraTexture, drawPos - new Vector2(439, 425), null, Color.White, 0f, drawOrigin, 2.5f, effects, 0);
			if (phase == 1 && arenaTimer > 0) {
				int dist = 500;
				float transitionAlpha = 1f;
				if (arenaTimer < 150) {
					dist = 1100-arenaTimer*4;
					transitionAlpha = arenaTimer/150f;
				}
				if (attackTimer > 2200) {
					dist = 500+(attackTimer-2200)*8;
					transitionAlpha = 1f-(attackTimer-2200)/120f;
				}

				if (Main.expertMode || Main.masterMode) for (int i = 0; i < 30; i++) {
					float speed = arenaTimer*0.5f;
					Vector2 arenaDrawPos = NPC.Center + new Vector2(0, dist).RotatedBy(MathHelper.ToRadians(speed+(i*12))) - screenPos + new Vector2(0f, NPC.gfxOffY) + new Vector2(texture.Width*1f, texture.Height*1f);
					spriteBatch.Draw(orangeTexture, arenaDrawPos, null, Color.White*transitionAlpha, 0f, arenaOrigin, 1f, SpriteEffects.None, 0);

					arenaDrawPos = NPC.Center + new Vector2(0, dist+(int)(30*Math.Sin((speed-130f)*Math.PI/20f))).RotatedBy(MathHelper.ToRadians(speed*1.6f+(i*12))) - screenPos + new Vector2(0f, NPC.gfxOffY) + new Vector2(texture.Width*1f, texture.Height*1f);
					spriteBatch.Draw(yellowTexture, arenaDrawPos, null, Color.White*transitionAlpha, 0f, arenaOrigin, 1f, SpriteEffects.None, 0);
				}
			}

			if (finale) {
				float flash = (float)-Math.Cos((float)attackTimer/20f)/8f + 1.125f;
				float newAlpha = 2f-flash;
				float transitionAlpha = 1f;
				if (attackTimer < 100) {
					transitionAlpha = attackTimer/100f;
				}

				spriteBatch.Draw(deathTexture, drawPos, null, color*newAlpha*transitionAlpha, OrbDrawRotation, drawOrigin, flash, effects, 0);
			}
			return false;
        }
		public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.HealingPotion;
			//ZylonWorldCheckSystem.downedAdeneb = true;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.AdenebTrophy>(), 10));

			notExpertRule.OnSuccess(new CommonDrop(ModContent.ItemType<Items.Vanity.AdenebMask>(), 7)).OnFailedRoll(new CommonDrop(ModContent.ItemType<Items.Vanity.PolandballMask>(), 10));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.AdeniteCrumbles>(), 1, 8, 12));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.SearedStone>(), 1, 40, 60));

			LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.RemixSeed());
			notExpertRule.OnSuccess(leadingConditionRule); //.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.AdeniteSecurityBlade>(), ModContent.ItemType<Items.Guns.AdeniteSecurityHandgun>(), ModContent.ItemType<Items.MagicGuns.AdeniteSecurityElectrifier>())));
			leadingConditionRule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.AdeniteSecurityBlade>(), ModContent.ItemType<Items.Guns.AdeniteSecurityHandgun>(), ModContent.ItemType<Items.MagicGuns.AdeniteSecurityElectrifier>()));
			
			npcLoot.Add(notExpertRule);

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<AdenebBag>()));

			npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeables.Relics.AdenebRelic>()));
			//npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MinionBossPetItem>(), 4));
		}
    }
}