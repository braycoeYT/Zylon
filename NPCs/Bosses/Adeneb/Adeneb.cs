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

namespace Zylon.NPCs.Bosses.Adeneb
{
	[AutoloadBossHead]
    public class Adeneb : ModNPC
	{

		//NPC.ai[0] is the current "phase"
		//NPC.ai[1] is the current attack
		//NPC.ai[2] is the attack timer

		// "Phases":
		// -1 - Represents the intro.
		// 0 - Represents phase 1
		// 1 - Represents the transition phase between 1 and 2
		// 2 - Represents phase 2
		// 3 - Represents the true finale, where the boss goes absolutley ape shit.

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
			NPC.value = 60000;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
			NPC.netAlways = true;
			NPC.lavaImmune = true;
			NPC.ai[0] = -1;
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
			// Finale attack trigger, only triggers in expert or master mode.
            if (NPC.life < 1 && (Main.expertMode || Main.masterMode) && NPC.ai[0] != 3) {
				NPC.life = 1;
				NPC.dontTakeDamage = true;
                NPC.ai[0] = 3;
				EndAttack();
            }
        }
		int attackTimer;
		int attackTimer2;
		int attackInt;
		int prevAttack;
		float attackFloat;
		float attackFloatFinale;
		float o;
		int angerTimer;
		int flee;
		bool transitionSetup;
		bool drawAura;
		int arenaSize = 800; //1000
		//bool adenebTurn = true;
		Vector2 dashVelocity;
		Vector2 tempVector;
		Vector2 newVel;
		Player target;
        public override void AI() {
			// Always target closest player. As long as the boss remains in sync this should always be true.
			NPC.TargetClosest();
			target = Main.player[NPC.target];
			// Set boss NPC to the NPC's ID
			ZylonGlobalNPC.adenebBoss = NPC.whoAmI;

			// This is a clever way of having to send less data over the network for the boss, freeing up an NPC.ai spot.
			bool attackDone = (NPC.ai[2] == -1);

			// Phase 1 stat code
			NPC.damage = 33;
			NPC.defense = 18;
			if (Main.expertMode) { NPC.damage = 61; }
			if (Main.masterMode) { NPC.damage = 92; }

			// Phase 2 stat code
			if (NPC.ai[0] == 2) {
				NPC.damage = 45;
				NPC.defense = 8;
				if (Main.expertMode) { NPC.damage = 75; }
				if (Main.masterMode) { NPC.damage = 109; }
            }

			// Enrage conditions.
			if (!target.ZoneDesert && !target.ZoneUndergroundDesert && !(NPC.ai[0] == 0 && NPC.life <= NPC.lifeMax / 2) && NPC.ai[0] != 3)
			{
				// If the enrage conditions are being met, increase the anger value.
				angerTimer++;
				// If the anger timer has gone up for 4 seconds, enrage the boss.
				if (angerTimer > 240)
				{
					// Multiply the damage value and give it insane defense.
					NPC.damage = (int)(NPC.damage * 1.5f);
					NPC.defense = 36;
				}
			}
			else
			{
				// Otherwise set the anger value of the boss to zero.
				angerTimer = 0;
			}

			// Buff NPC damage in a get good world.
			if (Main.getGoodWorld) NPC.damage = (int)(NPC.damage*1.33f);

			// Fleeing Code.
			// Get the closest player, if they have less then 1 HP, consider them dead.
			if (Main.player[NPC.target].statLife < 1) {
				// Grab the nearest player again.
				NPC.TargetClosest(true);
				// If they are also dead assume all hell broke loose.
				if (Main.player[NPC.target].statLife < 1) {
					// Begin increasing the flee value.
					flee++;
				}
				// Otherwise if the boss is in the middle of a stationary attack, despawn if a player is too far away
				else if ((NPC.ai[0] == 3 || (NPC.ai[0] == 0 && NPC.life <= NPC.lifeMax/2)) && Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 1700) {
					flee++;
                }
				else
                {
					// If none of these are true, don't attempt to flee.
					flee = 0;
				}
				if (flee > 0) {
					// If flee equals 1 set the flee velocity value to a Vector of zero.
					if (flee == 1) 
						newVel = Vector2.Zero;
					// Every ten frames add 1 to the flee velocity Y value.
					if (flee % 10 == 0)
						newVel.Y += 1;
					// If the boss is in a stationary attack change flee behaviour.
					if ((NPC.ai[0] == 0 && NPC.life <= NPC.lifeMax/2) || NPC.ai[0] == 3)
                    {
						// Don't move if in a stationary attack
						NPC.velocity = Vector2.Zero;
						// Flee faster then normal
						if (flee > 30)
							NPC.active = false;
					} 
					else
                    { // Otherwise behave as normal and flee much slower.
						NPC.velocity = newVel;
						if (flee > 300) 
							NPC.active = false;
					}
					// Don't run any other code beyond this besides fleeing.
					return;
				}
			}
			// If the boss is still in the first real phase, and it's HP is lower then half, then switch to phase 2 transition stage.
			if (NPC.ai[0] == 0 && NPC.life <= NPC.lifeMax / 2)
			{
                NPC.ai[0] = 1;
			}

			// If finale phase is active, run the finale behaviours then stop.
			if (NPC.ai[0] == 3) {
				FinaleBehaviour();
				return;
            }

			// Phase 2 transition stage.
			if (NPC.ai[0] == 1)
            {
				PhaseTransitionBehaviour();
				return;
            }
			
			// Boss intro.
			if (NPC.ai[0] == -1)
            {
				IntroBehaviour();
				return;
            }

			// If the current attack is marked as done, get ready for the next one.
			if (attackDone) {
				// If the intro dash is done or the boss is in phase 2, load up the next attack.
				if (NPC.ai[0] == 0 || NPC.ai[0] == 2) {
					if (NPC.ai[0] == 2) {
                        // Phase 2 attack loader.
                        NPC.ai[1] = Main.rand.Next(4);
						while (prevAttack == NPC.ai[1])
							NPC.ai[1] = Main.rand.Next(4);
                    }
					else if (NPC.ai[0] == 0) {
						// Phase 1 attack loader.
						/*NPC.ai[1] = Main.rand.Next(3);
						while (prevAttack == NPC.ai[1])
							NPC.ai[1] = Main.rand.Next(3);*/
						NPC.ai[0] = 0;
                    }
					// Setup new attack.
					NPC.ai[2] = 0;
					attackFloat = 0f;
					attackInt = 0;
					prevAttack = (int) NPC.ai[1];
					NPC.netUpdate = true;
                }
            }
			else 
			{
				// Otherwise run the attacks themselves.
				// Phase 1 attacks.
				if (NPC.ai[0] == 0) {
					switch (NPC.ai[1])
					{
						case 0:
							SpinLaser();
							break;
						case 1:
							ScaryChase();
							break;
						case 2:
							BigSun();
							break;

					} 
                }
				// Phase 2 attacks.
				else if (NPC.ai[0] == 2)
                {
					switch (NPC.ai[1])
					{
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
				}
            }
			// Orientation variables for draw code. I won't go over why these don't have to be synced but all you have to know is because they are based off a value that is synced so you don't need to sync them.
			SpikeGlobalDrawRotation = NPC.rotation;
			OrbDrawRotation = -NPC.rotation;
        }

		// Spin laser attack.
		// Boss spins and shoots projectiles the directions of the pyramids.
		private void SpinLaser() {
			attackTimer++;
			float turnRate = 1f;
			if (attackTimer <= 11) {
				turnRate = 1.2f-(0.2f*NPC.life/(NPC.lifeMax/2)); //sets turn speed
				if (turnRate > 1.2f) turnRate = 1.2f;
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
				
				if (attackTimer < 340) attackFloat += 0.0006f*turnRate;
				else attackFloat -= 0.0006f*turnRate;
				NPC.rotation += attackFloat;

				int x = (int)(4+(5*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)));
				if (x > 9) x = 9;

				if (attackTimer % x == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, 10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage/4, 0f);
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
			int x = (int)(60+(20*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)));
			if (x > 80) x = 80;
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
			int x = (int)(60*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2));
			if (x < 0) x = 0;
			if (attackTimer >= x) {
				attackTimer = -120;
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

		private void FinaleBehaviour()
        {
			NPC.ai[1] = 5;
			//NPC.velocity *= 0.95f;
			attackTimer++;

			if (attackTimer % 3 == 0 && attackTimer <= 180)
			{
				if (NPC.Center.Y > target.Center.Y) NPC.velocity.Y -= 1;
				else if (NPC.Center.Y < target.Center.Y - 144) NPC.velocity.Y += 1;
				else NPC.velocity.Y *= 0.8f;
				if (NPC.Center.X < target.Center.X - 300) NPC.velocity.X += 1;
				else if (NPC.Center.X > target.Center.X + 300) NPC.velocity.X -= 1;
				else NPC.velocity.X *= 0.8f;
			}
			else if (attackTimer > 180) NPC.velocity = Vector2.Zero; //NPC.velocity *= 0.9f;

			if (attackTimer == 181)
			{ //Give players time to get in position?
			  //if (Main.expertMode) arenaSize = 800;
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(arenaSize, 0), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebFinaleWall>(), NPC.damage, 0f);
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(arenaSize, 0), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebFinaleWall>(), NPC.damage, 0f);
			}

			if (attackTimer >= 5000)
			{
				NPC.immortal = false;
				NPC.dontTakeDamage = false;
				Main.player[NPC.target].ApplyDamageToNPC(NPC, 1000, 0f, 0);
			}

			if (attackTimer == 3900 && Main.netMode != NetmodeID.MultiplayerClient)
			{ //Final sun ring big x1
				attackFloatFinale = Main.rand.NextFloat(360f);
				for (int i = 0; i < 12; i++)
				{
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSunBig>(), NPC.damage / 3, 0f, -1, attackFloatFinale + i * 30, -200f);
				}
			}
			if (attackTimer >= 3400 && attackTimer < 3800)
			{ //Final sun ring small x4
				attackFloatFinale = Main.rand.NextFloat(360f);
				if (attackTimer % 100 == 0 && Main.netMode != NetmodeID.MultiplayerClient) for (int i = 0; i < 12; i++)
					{
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSun>(), NPC.damage / 3, 0f, -1, attackFloatFinale + i * 30, -200f);
					}
			}
			if (attackTimer >= 2800 && attackTimer < 3400)
			{ //Laser rain final
				if (attackTimer % 36 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
					Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(Main.rand.Next(-100, 101), 600), new Vector2(0, 7), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 3, 0f);
			}
			if (attackTimer >= 2550 && attackTimer < 3400)
			{ //Ring attack cool
				if (attackTimer == 2550) attackFloat = 0f;
				if (attackTimer % 5 == 0 && Main.netMode != NetmodeID.MultiplayerClient) for (int i = 0; i < 4; i++)
					{
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 1000).RotatedBy(MathHelper.ToRadians((i * 90) + attackFloat)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShotFinale>(), NPC.damage / 3, 0f);
					}
				attackFloat += 0.2f;// + attackFloatFinale;
			}
			if (attackTimer >= 2400 && attackTimer < 3400)
			{ //Big Sun pt2
				if (attackTimer % 300 == 0 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(-600, 600), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
				if (attackTimer % 300 == 150 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(600, 600), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
				//if (attackTimer == 2400 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(-600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage/3, 0f, -1, 0, 0, 1);
				//if (attackTimer == 2550 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage/3, 0f, -1, 0, 0, 1);
				//if (attackTimer == 2700 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(-600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage/3, 0f, -1, 0, 0, 1);
				//if (attackTimer == 2850 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage/3, 0f, -1, 0, 0, 1);
			}
			if (attackTimer >= 2100)
			{ //Sun rings at player pt2
				if (attackTimer == 2100) attackInt = 0;
				if (attackTimer % 100 == 0 && attackTimer < 2400)
				{
					attackInt++;
					int rotMult = 1;
					int rand = Main.rand.Next(360);
					if (attackInt % 200 == 0) rotMult = -1;
					for (int i = 0; i < 8; i++)
					{
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebFinaleSunRing>(), NPC.damage / 3, 0f, -1, rotMult * (i * 45) + rand);
					}
				}
			}
			if (attackTimer >= 1860 && attackTimer < 2060)
			{ //Laser rain pt2 - both up and down
				if (attackTimer % 10 == 0 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(Main.rand.Next((-1 * arenaSize) + 16, arenaSize - 16), 800), new Vector2(0, 7), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 3, 0f, -1, 1f);
				if (attackTimer % 10 == 5 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(Main.rand.Next((-1 * arenaSize) + 16, arenaSize - 16), -800), new Vector2(0, -7), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 3, 0f, -1, 1f);

				//if (attackTimer % 10 == 0 && attackTimer < 2100 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShotFinale>(), NPC.damage/3, 0f, -1, 0, 0, 1);
			}
			if (attackTimer >= 1400)
			{ //Big Sun pt1
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					if (attackTimer == 1400)
						Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(0, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
					if (attackTimer == 1500)
						Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(-600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
					if (attackTimer == 1600)
						Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(600, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
					if (attackTimer == 1700)
						Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center - new Vector2(0, 400), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebBigSun2>(), NPC.damage / 3, 0f, -1, 0, 0, 1);
				}
			}
			if (attackTimer >= 760)
			{ //Sun rings at player pt1
				if (attackTimer == 760) attackInt = 0;
				if (attackTimer % 120 == 0 && attackTimer < 1360)
				{
					attackInt++;
					int rotMult = 1;
					int rand = Main.rand.Next(360);
					if (attackInt % 2 == 0) rotMult = -1;
					for (int i = 0; i < 8; i++)
					{
						if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebFinaleSunRing>(), NPC.damage / 3, 0f, -1, rotMult * (i * 45) + rand);
					}
				}
			}
			if (attackTimer >= 300 && attackTimer < 800)
			{ //Laser rain pt1
				if (attackTimer % 5 == 0 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(Main.rand.Next((-1 * arenaSize) + 16, arenaSize - 16), 800), new Vector2(0, 7), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 3, 0f, -1, 1f);
			}

			if (attackTimer >= 241)
			{
				for (int x = 0; x < Main.maxPlayers; x++)
				{
					bool dist = Math.Abs(Main.player[x].Center.X - NPC.Center.X) > arenaSize - 16;
					bool dist2 = Math.Abs(Main.player[x].Center.Y - NPC.Center.Y) < 1600;
					if (dist && dist2) Main.player[x].AddBuff(ModContent.BuffType<Buffs.Debuffs.SearedFlame>(), 2);
				}
			}
		}

		private void PhaseTransitionBehaviour()
        {
			NPC.dontTakeDamage = true;
			if (!transitionSetup)
			{ //probably screwed up some attack by cutting it off btw
                NPC.ai[2] = 0;
				attackTimer = 0;
				attackTimer2 = 0;
				attackFloat = 0f;
				attackInt = 0;
				transitionSetup = true;
			}
			attackTimer++;
			if (attackTimer < 30)
			{ //slowdown transition pt 1
				NPC.velocity *= 0.8f;
			}
			else if (attackTimer < 60)
			{ //slowdown transition pt 2
				attackFloat += 0.25f;
			}
			else if (attackTimer < 150)
			{ //positioning
				if (attackTimer % 3 == 0)
				{
					if (NPC.Center.Y > target.Center.Y) NPC.velocity.Y -= 1;
					else if (NPC.Center.Y < target.Center.Y - 144) NPC.velocity.Y += 1;
					else NPC.velocity.Y *= 0.8f;
					if (NPC.Center.X < target.Center.X - 300) NPC.velocity.X += 1;
					else if (NPC.Center.X > target.Center.X + 300) NPC.velocity.X -= 1;
					else NPC.velocity.X *= 0.8f;
				}
				if (attackTimer == 149) tempVector = NPC.Center;
			}
			else if (attackTimer < 400)
			{ //gather the players
				NPC.velocity = Vector2.Zero;
				if (attackTimer % 10 == 0)
				{
					//start at 150, end at 400
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), tempVector - new Vector2(1200 - ((attackTimer - 150) * 4), 750), new Vector2(0, 20), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 4 + 5, 0f, Main.myPlayer);
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), tempVector + new Vector2(1200 - ((attackTimer - 150) * 4), -750), new Vector2(0, 20), ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebLaser>(), NPC.damage / 4 + 5, 0f, Main.myPlayer);
					//if (attackTimer)
				}
				if (attackTimer == 399)
				{
					drawAura = true; //Feel free to change any variable stuff idrc, just doing the bare minimum to show the general idea
				}
			} //No attack buff when out biome in phase transition
			else if (attackTimer < 520)
			{
				//insert aura creation animation if you want, otherwise remove this grace period
			}
			else if (attackTimer < 900)
			{ //Transition part 1
				if (attackTimer % 3 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
				{
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, -800).RotatedBy(MathHelper.ToRadians((attackTimer - 520) * 2)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage / 4 + 1, 0f, Main.myPlayer);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 800).RotatedBy(MathHelper.ToRadians((attackTimer - 520) * 2)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage / 4 + 1, 0f, Main.myPlayer);
				}
			}
			else if (attackTimer < 1200)
			{ //Transition part 2
				if (attackTimer % 6 == 0 && attackTimer > 960 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, -800).RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseShot>(), NPC.damage / 3, 0f, Main.myPlayer, 0.25f);
			}
			else if (attackTimer < 1621)
			{//Transition part 3
				float rand = Main.rand.NextFloat(0, 45);
				if (attackTimer % 120 == 60 && Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < 8; x++)
					{
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 800), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSun>(), NPC.damage / 3 + 2, 0f, Main.myPlayer, x * 45 + rand);
					}
			}
			else if (attackTimer < 2201)
			{ //End of transition
				if (attackTimer == 1800 && Main.netMode != NetmodeID.MultiplayerClient) for (int x = 0; x < 8; x++)
					{
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 800), Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebPhaseSunBig>(), NPC.damage / 3 + 4, 0f, Main.myPlayer, x * 45);
					}
				if (attackTimer == 2200)
				{
					//END OF TRANSITION phase, drawaura
					drawAura = false;
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.Adeneb.AdenebSunShield>(), NPC.damage / 3, 0f);
				}
			}
			else
			{
				if (attackTimer == 2320)
				{
                    //again change the length of this to fit anim
                    NPC.ai[0] = 2;
					prevAttack = -1;
					EndAttack();
					NPC.dontTakeDamage = false;
					NPC.rotation = 0f;
				}
			}


			NPC.rotation += MathHelper.ToRadians(attackFloat); //Do whatever you want for the visuals, remove this part if you want. This is just a placeholder since I am not the wacky visual man.
			SpikeGlobalDrawRotation = NPC.rotation;
			OrbDrawRotation = -NPC.rotation;

			if (drawAura)
			{
				for (int x = 0; x < Main.maxPlayers; x++)
				{
					float dist = Vector2.Distance(NPC.Center, Main.player[x].Center);
					if (dist > 500 && dist < 3000) Main.player[x].AddBuff(ModContent.BuffType<Buffs.Debuffs.SearedFlame>(), 2);
				}
			}
		}

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
			// Stop the boss from hurting players via contact damage if the boss is in any cutscene or transition phases.
			if (NPC.ai[0] == -1 || NPC.ai[0] == 1 || NPC.ai[0] == 3)
				return false;
            return base.CanHitPlayer(target, ref cooldownSlot);
        }

        private void IntroBehaviour()
        {
			// Add to the attack progress ai variable.
            NPC.ai[2]++;
			if (NPC.ai[2] == 1)
            {
				NPC.Center = target.Center + new Vector2(0, 300);
            }

			bool playIntro = false;
			if (Main.myPlayer < 255)
            {
				// If the distance between the boss and the player is less then 2000 units, set play intro to true.
				playIntro = (Vector2.Distance(Main.player[Main.myPlayer].Center, NPC.Center) < 2000);
            }
			// If the player is in valid range to be part of the intro, run the code.
			if (playIntro)
            {

            }
			// End intro if enough time has passed.
			if (NPC.ai[2] >= 600)
			{
				// Switch to phase 1
				Systems.Camera.CameraController.ReturnCamera(30);
                NPC.ai[0] = 0;
				EndAttack();
			}
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
			NPC.ai[1] = -1;
			NPC.ai[2] = -1;
			attackFloat = 0f;
			attackInt = 0;
			start = false;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A forgotten civilization's adopted protector, powered by a computer chip blessed by the sun god.")
			});
		}

		float OrbDrawRotation = 0f;
		float SpikeGlobalDrawRotation = 0f;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D spikeTextureTop = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_SpikeUpper");
			Texture2D spikeTextureBottom = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_SpikeLower");
			Texture2D ankhTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Ankh");
			Texture2D auraTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/Adeneb/Adeneb_Aura");

			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

			Vector2 spikeOrigin = spikeTextureTop.Size() * 0.5f;
			Vector2 ankhOrigin = ankhTexture.Size() * 0.5f;

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
			Color color = NPC.GetAlpha(drawColor);
			var effects = SpriteEffects.None;

			bool cond = NPC.ai[0] == 0 && !(NPC.life <= NPC.lifeMax/2 && attackTimer >= 2200);

			if (cond) spriteBatch.Draw(spikeTextureBottom, drawPos + new Vector2(0, 80).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, spikeOrigin, NPC.scale, effects, 0);
			spriteBatch.Draw(texture, drawPos, null, color, OrbDrawRotation, drawOrigin, NPC.scale, effects, 0);
			if (cond) spriteBatch.Draw(spikeTextureTop, drawPos + new Vector2(0, -80).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, spikeOrigin, NPC.scale, effects, 0);
			if (cond) spriteBatch.Draw(ankhTexture, drawPos + new Vector2(0, -20).RotatedBy(SpikeGlobalDrawRotation), null, color, SpikeGlobalDrawRotation, ankhOrigin, NPC.scale, effects, 0);

			if (drawAura) spriteBatch.Draw(auraTexture, drawPos - new Vector2(439, 425), null, Color.White, 0f, drawOrigin, 2.5f, effects, 0);

			return false;
        }
		public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.RestorationPotion;
			//ZylonWorldCheckSystem.downedAdeneb = true;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (Main.masterMode) {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Relics.AdenebRelic>(), 1));
				//npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.>(), 4));
            }
			if (Main.expertMode || Main.masterMode) npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bags.AdenebBag>(), 1));
			else {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.AdeniteCrumbles>(), 1, 8, 12));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.SearedStone>(), 1, 40, 60));

				//Only drop these weapons if in Remix or getfixedboi worlds
				LeadingConditionRule leadingConditionRule = new LeadingConditionRule(new Conditions.RemixSeed());
				LeadingConditionRule leadingConditionRule2 = new LeadingConditionRule(new Conditions.ZenithSeedIsUp());

				leadingConditionRule.OnSuccess(npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.AdeniteSecurityBlade>(), ModContent.ItemType<Items.Guns.AdeniteSecurityHandgun>(), ModContent.ItemType<Items.MagicGuns.AdeniteSecurityElectrifier>())));
				leadingConditionRule2.OnSuccess(npcLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Swords.AdeniteSecurityBlade>(), ModContent.ItemType<Items.Guns.AdeniteSecurityHandgun>(), ModContent.ItemType<Items.MagicGuns.AdeniteSecurityElectrifier>())));

				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.AdenebMask>(), 7)).OnFailedRoll(npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.PolandballMask>(), 10)));
            }
			//npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.AdenebTrophy>(), 10));
		}
    }
}