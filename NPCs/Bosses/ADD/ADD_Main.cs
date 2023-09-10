using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
	[AutoloadBossHead]
    public class ADD_Main : ModNPC
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Ancient Diskite Director");
            //Main.npcFrameCount[NPC.type] = 3;
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
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/Bosses/ADD/ADD_Bestiary",
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
			//NPC.DeathSound = SoundID.NPCDeath14;
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
        NPC.lifeMax = (int)((5200 + ((numPlayers - 1) * 1200))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 61;
			NPC.value = 140000;
			if (Main.masterMode) {
				NPC.lifeMax = (int)((3400 + ((numPlayers - 1) * 1400))*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 94;
            }
        }
		int attack;
		int attackTimer;
		int attackTimer2;
		int attackInt;
		float attackFloat;
		float o;
		bool attackDone = true;
		int phase = 1;
		Vector2 veloz;
		Player target;
        public override void AI() {
			/*if (NPC.CountNPCS(ModContent.NPCType<ADD_Ankh>()) > 0) {
				NPC.dontTakeDamage = true;
            }*/
			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.diskiteBoss = NPC.whoAmI;
			if (attackDone) { //THIS IS THE DASH ATTACK FOR BOTH PHASES BTW

				//old test
				//NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * (float)(-5.5f);
				//NPC.rotation += 0.03f;
				//NPC.rotation = NPC.velocity.X * 0.08f;

				attackTimer++;

				if (attackTimer == 1) { //Note to self: change to make crazy in p2, go alterante if route
					float h = -80f+(20f*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)); //-80, 20
					if (h < -80f) h = -80f;
					veloz = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center) * h;
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center+veloz, veloz, ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskitePremonition>(), 0, 0, Main.myPlayer, 20);
                }
				if (attackTimer < 10) {
					NPC.velocity /= 2;
                }
				if (attackTimer == 60) {
					veloz.Normalize();
					NPC.velocity = veloz*24f;
					o = 0.1f;
					if (Main.expertMode) o += 0.025f;
				}
				if (attackTimer > 60) {
					NPC.velocity *= 0.95f; //0.96
					o *= 0.972f; //0.97
					NPC.rotation += o*3f;//*(0.1f+(0.015f*120-attackTimer));
				}

				if (attackTimer >= 150) { //ATTACK SETUP
					if (attackTimer2 == 0) {
						attackTimer2 = 1;
						attackTimer = 0;
                    }
					else {
						//attack = Main.rand.Next(1);
						attack = 2;
						attackDone = false;
						attackTimer = 0;
						attackTimer2 = 0;
						attackFloat = 0f;
						attackInt = 0;
					}
                }
            }
			else { //See tome man? I'm doing a thing!
				switch (attack) {
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
            }
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

				int x = (int)(4+(5*(NPC.life-NPC.lifeMax/2)/(NPC.lifeMax/2)));
				if (x > 9) x = 9;

				if (attackTimer % x == 0 && Main.netMode != NetmodeID.MultiplayerClient) {
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteLaser>(), NPC.damage/3, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, 10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteLaser>(), NPC.damage/3, 0f);
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
				Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, 10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteXBeam>(), NPC.damage/3+5, 0f);
				attackTimer2++;
			}

			if (attackTimer2 > 12) EndAttack();
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
				if (attackTimer2 <= attackInt) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center - new Vector2(0, 70).RotatedBy(NPC.rotation), new Vector2(0, -10).RotatedBy(NPC.rotation), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteBigSun>(), NPC.damage/3+8, 0f);
				attackTimer2++;
				if (attackTimer2 > attackInt + 1) EndAttack();
            }
        }
		/*private void ElecChase() {
			attackTimer++;
			if (attackTimer >= (int)(40+(30*NPC.life/(NPC.lifeMax)))) {
				attackTimer2++;
				if (Main.netMode != NetmodeID.MultiplayerClient) {

                }
            }
			if (attackTimer2 > 3) EndAttack();
        }*/
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
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A forgotten civilization's adopted protector, powered by a chip connected to the sun god.")
			});
		}
    }
}