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
using Terraria.GameContent.ItemDropRules;
using Zylon.Items.Bags;

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
			NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Daybreak] = true;
			NPCID.Sets.SpecificDebuffImmunity[Type][ModContent.BuffType<Buffs.Debuffs.Timestop>()] = true;

			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				CustomTexturePath = "Zylon/NPCs/Bosses/SaburRex/SaburRex_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}
        public override void SetDefaults() {
            NPC.width = 58;
			NPC.height = 64;
			NPC.damage = 99;
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
			Music = MusicID.Boss4;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(500000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 199;
			NPC.value = Item.buyPrice(7, 50);
			if (Main.masterMode) {
				NPC.lifeMax = (int)(650000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 299;
            }
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot) {
			if ((NPC.ai[0] == 0 && NPC.ai[3] == 1) || (NPC.ai[0] == 4f && NPC.ai[3] == 0f)) return false; //See influx weaver and tizona code - prevent frustration.
            return true;
        }
        public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers) {
            if (projectile.type == ProjectileID.FinalFractal) modifiers.FinalDamage *= 0.66f; //I wanted to unnerf Zenith a little but not let it obliterate the mod's final boss
        }
        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers) {
            modifiers.SetMaxDamage(9999); //Anticheat + jrpg reference
        }
		public override void HitEffect(NPC.HitInfo hit) {
            if (NPC.life < 1 && !finale) {
				NPC.life = 1;
				NPC.dontTakeDamage = true;
				finale = true;
				attackTimer = 0;
				NPC.velocity = Vector2.Zero;
				NPC.frame.Y = 0;
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
            if (Main.expertMode && NPC.ai[0] == 1f && NPC.ai[3] == 1f) target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was sent to the dungeon."), 999, NPC.direction); //We are NOT messing around.
        }
        float ringTotalRot = Main.rand.Next(360); //Sets border to start at a random position so it is different each time.
		float ringRotSpeed;
		float prevAttack = -1f;
		float descendVel = 11f; //10f og
		bool attackDone = true;
        bool init;
		int attackTimer;
		bool dialogue;
		Vector2 ringPos;
		int ringSpace = 250;
		int attackNum;
		float hpLeft;
		int attackTotalTime;
		float attackFloat;
		float attackFloat2;
		int attackNum2;
		int attackNum3;
		Player target;
		int attackNum4;
		int attackNum5;
		float attackFloat3;
		int attackNum6;
		float attackFloat4;
		int attackNum7;
		int attackNum8;
		int attackNum9;
		bool finale;
        public override bool PreAI() {
			if (finale) {
				attackTimer++;
				NPC.velocity.Y = -(float)Math.Pow(attackTimer/50f, 5f);
				ringRotSpeed *= 1.07f;
				ringTotalRot += ringRotSpeed; //Rotate the boss ring.
				if (NPC.Center.Y < target.Center.Y-600) {
					NPC.dontTakeDamage = false;
					if (Main.netMode != NetmodeID.MultiplayerClient) NPC.StrikeInstantKill();
				}
			}
            return !finale;
        }
		int flee;
        public override void AI() { //ai0 - current attack | ai1 - next attack | ai2 - current rotation | ai3 - other important communication w/ sword proj
			if (Main.player[NPC.target].statLife < 1 && !finale) {
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1) {
					flee++;
				}
				else
				flee = 0;
				if (flee > 0) {
					if (flee > 300) NPC.active = false;
					//return;
				}
			}

			Zylon.hasFoughtSabur = true; //REMOVE WHEN BOSS FINISHED - JUST TO SKIP DIALOGUE

			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.saburBoss = NPC.whoAmI;

			if (!init) { //Sets up two floating sword projectiles + white light intro + dialogue
				attackTimer++; //Intro lasts two seconds

				ringRotSpeed = 1f; //Sets rotation speed of the rainbow ring. //og 0.5

				if (attackTimer < 120) {
					NPC.position.Y += descendVel;
					descendVel *= 0.974f; //0.978f og
					for (int i = 0; i < 2; i++) {
						int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.PureWhiteDust>());
						Dust dust = Main.dust[dustIndex];
						float mult = 1f;
						if (Main.rand.NextBool()) mult = -1f;
						dust.velocity.X = Main.rand.NextFloat(-3f, 3f); //Main.rand.NextFloat(3f, 6f)*mult;
						dust.velocity.Y = Main.rand.NextFloat(-3f, 3f); //Main.rand.Next(-50, 51) * 0.02f;
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
				
				if (dialogue) {
					if (attackTimer == 150) Main.NewText("A challenger?", 75, 104, 113);
					if (attackTimer == 310) Main.NewText("You are not who I am searching for...", 75, 104, 113);
					if (attackTimer == 470) Main.NewText("But I shall end your life regardless.", 75, 104, 113);
				}
				
				if (attackTimer == 500 || (attackTimer == 180 && !dialogue)) {

					//Set up swords twice to get first two values | If we don't do this then the boss gets confused
					NPC.ai[0] = -1f;
					NPC.ai[1] = -1f;
					NewAttack();
					NewAttack();

					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, Vector2.Zero, ModContent.ProjectileType<SaburRexSwordActive>(), NPC.damage/3, 0f);
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position, Vector2.Zero, ModContent.ProjectileType<SaburRexSwordFollow>(), NPC.damage/3, 0f);
					init = true;
				}
				
				UpdateFrame();
				if (!init) return;
			}

			if (attackDone) NewAttack(); //Determine new attack

			//Main.NewText(NPC.ai[0] + " | next: " + NPC.ai[1]); //Test

			switch (NPC.ai[0]) { //What attack is happening right now?
				case 0f:
					InfluxWaver();
					break;
				case 1f:
					BoneSword();
					break;
				case 2f:
					Katana();
					break;
				case 3f:
					BeeKeeper();
					break;
				case 4f:
					Tizona();
					break;
				case 5f:
					CobaltSword();
					break;
				case 6f:
					ChlorophyteSaber();
					break;
				case 7f:
					Starfury();
					break;
            }

			UpdateFrame();
        }
		private void InfluxWaver() {
			attackTimer++;
			PlayerSwingEffect(9.5f); //Sword anim

			//Vertical movement
			if (NPC.Center.Y < target.Center.Y - 320) NPC.velocity.Y += 1.5f;
			else if (NPC.Center.Y > target.Center.Y - 200) NPC.velocity.Y -= 1.5f;
			else if (Math.Abs(NPC.velocity.Y) > 0.5f) NPC.velocity *= 0.96f; //Target zone, so slow down
			if (Math.Abs(NPC.velocity.Y) > 13f) NPC.velocity *= 0.9f; //Reduces chaos.

			//Horizontal Movement
			if (attackNum % 2 == 0) {
				NPC.velocity.X += 1f;
				if (NPC.Center.X > target.Center.X + 120) attackNum++;
			}
			else {
				NPC.velocity.X -= 1f;
				if (NPC.Center.X < target.Center.X - 120) attackNum++;
			}
			NPC.velocity.X *= 0.96f;

			//Spawn UFO projectiles
			int normal = 5;
			if (Main.expertMode) normal = 0; //og below 25 + 20
			if (attackTimer >= 20+(int)(20*hpLeft)+normal && attackTimer < 370+(int)(200*hpLeft)) {
				if (attackTotalTime <= 400+(int)(200*hpLeft)-30) //Decreases the amount of UFOs that appear in the next attack to reduce frustration
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(0, 50)), Vector2.Zero, ModContent.ProjectileType<SaburRexMartianSaucer>(), (int)(NPC.damage*0.15f), 0f);
				attackTimer = 0;
			}

			//Removing frustration from attack transitions
			NPC.ai[3] = attackTotalTime < 60 ? 1f : 0f;

			//End attack
			if (attackTotalTime >= 400+(int)(200*hpLeft)) attackDone = true;
        }
		private void BoneSword() {
			//Spin acceleration
			attackFloat += MathHelper.ToRadians(0.6f)-MathHelper.ToRadians(0.47f*hpLeft);
			if (attackFloat > MathHelper.ToRadians(18f)) { attackFloat = MathHelper.ToRadians(18f); NPC.ai[3] = 1f; } //ai3 tells activeSword to activate instakill mode
			else { attackNum4 = 120; NPC.velocity *= 0.9f; } //Initializes bone outside attack and slows boss down.
			NPC.ai[2] += attackFloat;

			//Controls spin of dungeon guardian
			attackFloat2 += MathHelper.ToRadians(15)*NPC.direction; //It matches the sword better this way.

			//Movement
			if (attackFloat == MathHelper.ToRadians(18f)) {
				attackNum++; attackNum2++; attackNum4++; //This has to be 3 vars bc two of them have to be reset at very specific times
				if (attackNum % 20 == 1) {
					float speed = 8.25f-(0.75f*hpLeft);
					if (!Main.expertMode) speed *= 0.9f;
					NPC.velocity = NPC.DirectionTo(target.Center)*speed;
				}
				if (target.statLife < 1 && !target.active) {
					NPC.velocity = Vector2.Zero;
				}

				//Bone projectile
				if (attackNum2 > 120*hpLeft) {
					attackNum3++; //ik this is a ton of variables but idk how to narrow it down
					if (attackNum3 % 12 == 1 && Main.netMode != NetmodeID.MultiplayerClient) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexBoneProj>(), (int)(NPC.damage/4), 0f);
					}
					if (attackNum3 > 60) { //Attack over, reset variables
						attackNum2 = 0;
						attackNum3 = 0;
					}
				}

				//Bone projectile from outside ring

				if (attackNum5 > 3) {
					attackNum4++;
					if (attackNum4 > 180+(int)(45*hpLeft)) attackDone = true; //og 150+45
					return;
				}

				if (attackNum4 > 240) { //og 180
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int i = -800; i < 801; i += 200+(int)(24*hpLeft)) {
						Vector2 bonePos = ringPos - new Vector2(i, 850).RotatedBy(MathHelper.ToRadians(attackNum5*90)); //(i, Main.rand.Next(800, 901)) //idk if I want a uniform wall or a randomized one
						Projectile.NewProjectile(NPC.GetSource_FromThis(), bonePos, new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(attackNum5*90)), ModContent.ProjectileType<SaburRexBoneProjOutside>(), (int)(NPC.damage/4), 0f);
					}
					attackNum5++;
					attackNum4 = 0;
				}
			}

			//Test
			//Main.NewText(MathHelper.ToDegrees(attackFloat) + " | " + (MathHelper.ToDegrees(attackFloat)-13f)/10f);
			//Main.NewText(NPC.ai[2] + " | " + MathHelper.ToDegrees(attackFloat));
		}
		private void Katana() { //NPC direction code in UpdateFrame is disabled for this attack, also I feel so braindead after making this so not that many comments
			if (attackTotalTime == 1) attackNum5 = (int)(30+(15*hpLeft));
			if (attackTotalTime < attackNum5) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.RedTorch);
				dust.velocity = new Vector2(0, -3).RotatedBy(MathHelper.TwoPi*(attackTotalTime/attackNum5));
				dust.noGravity = true;
				dust.scale = 2f;
				return; //Giving time for players to prepare, but they won't listen of course.
			} //It takes until at least the third attempt for them to integrate this dust sequence into their nightmares. Happy dreaming, players!
			else if (attackTotalTime < 40) attackNum5 = 0; //Umm... I don't remember writing that...
			attackTimer++;
			if (attackNum2 % 4 == 3) {
				NPC.velocity *= 0.9f;
				if (attackTimer == 1) {
					attackFloat = 0f;

					if (NPC.DirectionTo(target.Center).X > 0) NPC.direction = 1;
					else NPC.direction = -1;
					attackNum5 = NPC.direction;
					attackNum4 = Main.rand.Next(360);
					attackNum3 = 0;
				}
				NPC.direction = attackNum5;

				attackFloat += MathHelper.ToRadians(3.2f+(0.8f*hpLeft));

				//The eternal struggle to syncketh thy blade with thy projectiles.
				if (attackNum5 == 1) NPC.ai[2] = attackFloat; //+ MathHelper.ToRadians(attackNum4);
					else NPC.ai[2] = -1*attackFloat; //- MathHelper.ToRadians(attackNum4);
				NPC.ai[2] += MathHelper.Pi;
				
				//if (NPC.direction == 1) NPC.ai[2] = NPC.DirectionTo(target.Center).ToRotation() + MathHelper.PiOver2;
				//	else NPC.ai[2] = -1*NPC.DirectionTo(target.Center).ToRotation() - MathHelper.PiOver2;

				if (attackTimer % 3 == 0 && attackNum3 < 1) {
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 48).RotatedBy(attackFloat), new Vector2(0, 5).RotatedBy(attackFloat), ModContent.ProjectileType<SaburRexKatanaDuplicate>(), (int)(NPC.damage*0.23f), 0f, -1, ringPos.X, ringPos.Y, attackNum4);
				}
				if (Math.Abs(attackFloat) >= MathHelper.TwoPi*2) {
					attackNum3++;
					if (attackNum3 > 20 && attackNum2 < 11) {
						attackNum2++;
						attackTimer = 0;
					}
					else if (attackNum3 > 40 && attackNum2 == 11) {
						attackDone = true;
					}
				}
			}
			else {
				if (attackTimer <= 15) {
					//Gets sword to point at the player correctly. Much easier to do it here than in the sword code, trust me.
					if (NPC.direction == 1) NPC.ai[2] = NPC.DirectionTo(target.Center).ToRotation() + MathHelper.PiOver2;
					else NPC.ai[2] = -1*NPC.DirectionTo(target.Center).ToRotation() - MathHelper.PiOver2;
					
					if (NPC.DirectionTo(target.Center).X > 0) NPC.direction = 1;
					else NPC.direction = -1;
					attackNum = NPC.direction;
					if (attackTimer == 15) {
						NPC.velocity = NPC.DirectionTo(target.Center)*(38f-(8f*hpLeft)); //og 45 - 15
					}
				}
				else if (attackTimer < 45) {
					NPC.direction = attackNum; //Don't allow him to flip directions while dashing.
					NPC.velocity *= 0.935f; //og 0.94
	
					//Katana duplicates
					if (Main.netMode != NetmodeID.MultiplayerClient && (attackTimer % (2+(int)(3*hpLeft)) == 0) && attackTimer < (50+(int)(25*hpLeft))) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-3f, 3f))), ModContent.ProjectileType<SaburRexKatanaDuplicate>(), (int)(NPC.damage*0.23f), 0f, -1, ringPos.X, ringPos.Y);
					}
				}
				else {
					attackTimer = 0;
					attackNum2++;
					attackNum5 = 0;
				}
			}
		}
		private void BeeKeeper() {
			//Dashing and whatnot.
			attackTimer++;
			if (attackTimer == 1) {
				//What direction to dash? -1 = goes to left side to dash right, 1 = goes to right side to dash left.
				if (NPC.Center.X > target.Center.X) attackNum2 = 1;
				else attackNum2 = -1;

				attackNum3 = 0; //Don't draw the queen bee thing.
			}
			else if (attackNum5 < 10) {
				NPC.direction = attackNum2*-1;
				NPC.ai[2] = MathHelper.ToRadians(90);
				if (attackNum2 == -1) {
					//Horizontal
					if (NPC.Center.X < target.Center.X - 600) NPC.velocity.X += 3f-2f*hpLeft;
					else if (NPC.Center.X > target.Center.X - 540) NPC.velocity.X -= 3;
					else {
						if (Math.Abs(NPC.velocity.X) > 0.5f) NPC.velocity.X *= 0.96f;
						if (Math.Abs(NPC.Center.Y-target.Center.Y) < 150) attackNum5++; //Sweet spot.
					}
					if (Math.Abs(NPC.velocity.X) > 15f) NPC.velocity *= 0.9f; //Please don't accidentally stumble over the player.

					//Vertical
					if (NPC.Center.Y < target.Center.Y - 50) NPC.velocity.Y += 4f-2f*hpLeft;
					else if (NPC.Center.Y > target.Center.Y + 50) NPC.velocity.Y -= 4f-2f*hpLeft;
					else if (Math.Abs(NPC.velocity.Y) > 0.5f) NPC.velocity.Y *= 0.93f;

					if (Math.Abs(NPC.velocity.Y) > 18f) NPC.velocity *= 0.93f; //og 0.9
				}
				else {
					//Horizontal
					if (NPC.Center.X > target.Center.X + 600) NPC.velocity.X -= 3f-2f*hpLeft;
					else if (NPC.Center.X < target.Center.X + 540) NPC.velocity.X += 3;
					else {
						if (Math.Abs(NPC.velocity.X) > 0.5f) NPC.velocity.X *= 0.96f;
						if (Math.Abs(NPC.Center.Y-target.Center.Y) < 150) attackNum5++; //Sweet spot.
					}
					if (Math.Abs(NPC.velocity.X) > 15f) NPC.velocity *= 0.9f; //Please don't accidentally stumble over the player.

					//Vertical
					if (NPC.Center.Y < target.Center.Y - 50) NPC.velocity.Y += 4f-2f*hpLeft;
					else if (NPC.Center.Y > target.Center.Y + 50) NPC.velocity.Y -= 4f-2f*hpLeft;
					else if (Math.Abs(NPC.velocity.Y) > 0.5f) NPC.velocity.Y *= 0.93f;

					if (Math.Abs(NPC.velocity.Y) > 18f) NPC.velocity *= 0.93f; //og 0.9
				}
			}
			else {
				NPC.direction = attackNum2*-1; //This here is really important for npc direction to work, for some reason.
				attackNum3 = 1; //You should draw the queen bee.
				if (attackNum2 == -1) {
					NPC.velocity.X = 32-(int)(8f*hpLeft); //og 36, 16 - too easy then too hard?
					NPC.velocity.Y = 0; //*= 0.92f;
					if (NPC.Center.X > target.Center.X + 400) {
						attackTimer = 0;
						NPC.velocity = Vector2.Zero;
						attackNum5 = 0;

						attackNum4++; //Will end the attack once high enough.
					}
				}
				else {
					NPC.velocity.X = -32+(int)(8f*hpLeft); //og 36, 16 - too easy then too hard?
					NPC.velocity.Y = 0; //*= 0.92f;
					if (NPC.Center.X < target.Center.X - 400) {
						attackTimer = 0;
						NPC.velocity = Vector2.Zero;
						attackNum5 = 0;

						attackNum4++; //Will end the attack once high enough.
					}
				}
			}

			//End attack
			if (attackNum4 > (int)(14-(8*hpLeft))) attackDone = true;

			//Honeypot projectiles
			attackNum6++;
			if (attackNum6 > 90+(int)(180*hpLeft)) {
				attackNum6 = 0;
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.SaburRex.SaburRexHoneyPot>(), (int)(NPC.damage/4), 0f, -1, NPC.target, hpLeft);
			}
		}
		private void Tizona() { //Warning: This attack doesn't unload properly if forced to repeat multiple times in a row, beware.
			if (attackNum2 == 0) { //Intro - spawn servants to spin
				attackTimer++;
				if (attackTimer == 1) {
					attackFloat = Main.rand.NextFloat(18f, 22f)*(1.25f-(0.25f*hpLeft)); //og 1.75f and 0.75f - too hard
					attackNum = (int)(45+(75*hpLeft));

					//Determines how many projectiles to make.
					int dif = -1;
					if (Main.expertMode) dif = 0;
					if (Main.getGoodWorld) dif = 1;

					attackNum3 = (int)(9f-6f*hpLeft); //og 10f and 7f - too hard.
					if (attackNum3 == 3) attackNum3 = 4;

					attackNum3 += dif;

					//Move to center - Remember, NO COLLISION FOR THIS!!!
					NPC.velocity = (ringPos - NPC.Center)/(float)attackNum;
				}
				if (attackTimer == (attackNum/2)) {
					int timeLeft = attackNum-(attackNum/2);
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int i = 1; i < 5; i++) for (int j = 0; j < attackNum3; j++)
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexServantofOcram>(), (int)(NPC.damage/4), 0f, -1, i*200, j*(int)(360f/attackNum3), timeLeft);

					//Center proj
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexServantofOcram>(), (int)(NPC.damage/4), 0f, -1, 0, 0, timeLeft);
				}
				if (attackTimer < attackNum) { //Spinning animation - smooth through trig.
					NPC.ai[2] += MathHelper.ToRadians(attackFloat*(float)Math.Sin((float)attackTimer*Math.PI/(float)attackNum));
				}
				else if (attackTimer == attackNum+10) {
					NPC.velocity = Vector2.Zero;
					attackTimer = 0;
					attackNum = 0;
					attackNum2 = 1;
				}
			}
			else if (attackNum2 == 1) { //The intro is finished.
				PlayerSwingEffect(7.5f); //Sword anim
				if (attackTimer == 0) { //Just set attackTimer to 0 to choose a new attack - the rest is handled here.
					//attackNum = attackNum2;
					attackNum++;

					//Reset variables used
					attackFloat2 = 0f;
					attackFloat3 = 0f;
					attackFloat4 = 0f;
				}
				attackTimer++;
				
				if (attackNum % 2 == 0) { //Spin too fast while motionless attack
					NPC.velocity *= 0.9f;

					if (attackTimer >= 126 && attackTimer <= 188) NPC.ai[3] += MathHelper.ToRadians(200); //Forces speed of extremum
					else if (attackTimer <= 126) NPC.ai[3] += MathHelper.ToRadians(-100*(float)Math.Cos(attackTimer/40f)+100); //Starts extra slow to warn player
					else NPC.ai[3] += MathHelper.ToRadians(-100*(float)Math.Cos(attackTimer/20f)+100); //Normal speed
					
					if (attackTimer >= 250) {
						attackTimer = 0;
					}
				}
				else { //Slowly chase player as projectiles spin
					if (attackTimer == 1) {
						//Initializes spin speed - not related to velocity, just reusing variables bc I'm smart like that
						attackFloat2 = Main.rand.NextFloat(0.8f, 0.85f)*(1.5f-(0.5f*hpLeft));
						attackFloat3 = 1f;
						if (Main.rand.NextBool()) attackFloat3 = -1f;

						attackFloat4 = attackFloat2*attackFloat3;

						//Okay, now get them ready
						attackFloat2 = NPC.velocity.X;
						attackFloat3 = NPC.velocity.Y;

						attackNum4 = Main.rand.Next(2); //Vertical or Horizontal?
						attackNum5 = 1;
						if (Main.rand.NextBool()) attackNum5 = -1; //random direction
					}

					//Rotation of Ocram servants
					if (attackTimer > 340) NPC.ai[3] += attackFloat4*(float)(0.05f*(360f-attackTimer));
					else if (attackTimer < 20) NPC.ai[3] += attackFloat4*(float)(0.05f*attackTimer);
					else NPC.ai[3] += attackFloat4; //See above for initialization.

					//float2 - X speed | float3 - Y speed

					if (attackTimer < 5) {
						NPC.velocity *= 0.9f;
						return;
					}

					//Horizontal
					if (NPC.Center.X < target.Center.X) attackFloat2 += 0.3f; //0.2f
					else attackFloat2 -= 0.3f; //0.4f
					if (Math.Abs(attackFloat2) > 7f && Vector2.Distance(NPC.Center, target.Center) < 800) attackFloat2 *= 0.95f;

					//Vertical
					if (NPC.Center.Y < target.Center.Y) attackFloat3 += 0.3f; //0.2f
					else attackFloat3 -= 0.3f; //0.4f
					if (Math.Abs(attackFloat3) > 7f && Vector2.Distance(NPC.Center, target.Center) < 800) attackFloat3 *= 0.95f;

					NPC.velocity = new Vector2(attackFloat2, attackFloat3);

					if (attackTimer >= 360) { //End of attack
						attackTimer = 0;
					}
				}

				if (attackNum > 4) attackDone = true;

				//Sample test
				//NPC.ai[3] += MathHelper.ToRadians(50f*(float)Math.Sin(attackTimer/60f));
			}
			//if (attackTimer > 120) attackDone = true;
		}
		private void CobaltSword() {
			attackTimer++;
			if (attackNum == 0) {
				NPC.velocity *= 0.93f;
				if (attackTimer == 1) { //Random color to draw the arrows in.
					attackNum3 = Main.rand.Next(127, 256);
					attackNum4 = Main.rand.Next(127, 256);
					attackNum5 = Main.rand.Next(127, 256);
				}

				if (NPC.direction == 1) NPC.ai[2] = NPC.DirectionTo(target.Center).ToRotation() + MathHelper.PiOver2;
				else NPC.ai[2] = -1*NPC.DirectionTo(target.Center).ToRotation() - MathHelper.PiOver2;
				
				if (NPC.DirectionTo(target.Center).X > 0) NPC.direction = 1;
				else NPC.direction = -1;

				if (attackNum2 < 21 && attackTimer % 2 == 0) attackNum2++; //Length of arrow trail. 21 tells the drawer that it's done.

				if (attackTimer > 90) { attackNum = 1; attackTimer = 0; }

				attackFloat2 = NPC.Center.X;
				attackFloat3 = NPC.Center.Y;
				attackFloat4 = NPC.ai[2];
				attackNum8 = NPC.direction;
			}
			else if (attackNum == 1) {
				if (attackTimer == 1) {
					float rot = NPC.ai[2] + MathHelper.Pi;
					if (NPC.direction == -1) rot = -NPC.ai[2] + MathHelper.Pi;
					NPC.velocity = new Vector2(0, 48f-(24f*hpLeft)).RotatedBy(rot);
					SoundEngine.PlaySound(SoundID.Item1, NPC.Center);
				}
				else NPC.velocity *= 0.975f;
				attackFloat += NPC.velocity.Length();
				attackNum6 = (int)(attackFloat/36f)+1;
				if (attackNum6 > 22) {
					attackTimer = 0;
					attackFloat = 0f;
					attackNum = 0;
					attackNum2 = 0;
					attackNum6 = 0;

					attackNum7++;
				}
			}

			if (attackNum7 == 8) attackDone = true;

			//Spawn duplicates
			if (attackNum7 < 7) {
				attackNum9++;
				if (attackNum9 > (int)(25f+(20f*hpLeft))) {
					attackNum9 = 0;
					if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center + new Vector2(400, 601).RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<SaburRexCobaltClone>(), (int)(NPC.damage/4), 0f);
				}
			}
		}
		private void ChlorophyteSaber() {
			attackNum2++;
			PlayerSwingEffect(9.6875f);

			Vector2 spinCenter = target.Center; //- new Vector2(0, 300).RotatedBy(MathHelper.ToRadians(attackTotalTime*2.5f));
			
			if (attackTotalTime > 40 || hpLeft < 0.99f) { //No jumpscaring the new players.
				//Horizontal
				if (NPC.Center.X < spinCenter.X) attackFloat2 += 0.25f;
				else attackFloat2 -= 0.25f;
				if (Math.Abs(attackFloat2) > 5f && Vector2.Distance(NPC.Center, spinCenter) < 800) attackFloat2 *= 0.95f;
	
				//Vertical
				if (NPC.Center.Y < spinCenter.Y) attackFloat3 += 0.25f;
				else attackFloat3 -= 0.25f;
				if (Math.Abs(attackFloat3) > 5f && Vector2.Distance(NPC.Center, spinCenter) < 800) attackFloat3 *= 0.95f;

				NPC.velocity = new Vector2(attackFloat2, attackFloat3);
			}

			if (attackNum2 > (int)(25f+(25f*hpLeft))) {
				attackNum2 = 0;
				int rand1 = 1;
				if (Main.rand.NextBool()) rand1 = -1;
				int rand2 = 1;
				if (Main.rand.NextBool()) rand2 = -1;
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(200, 401)*rand1, Main.rand.Next(200, 401)*rand2), Vector2.Zero, ModContent.ProjectileType<SaburRexChlorophyteOrb>(), (int)(NPC.damage/4), 0f);
			}

			if (attackTotalTime > 600) {
				attackDone = true;
			}
		}
		private void Starfury() {
			NPC.timeLeft = 300; //One time he despawned while he was doing this attack
			if (attackTotalTime < 10) NPC.velocity *= 0.8f;
			else if (attackTotalTime == 10) { NPC.velocity = Vector2.Zero; attackNum6 = Main.rand.Next(2); }
			else NPC.velocity.Y = (float)Math.Cos(attackTotalTime*(float)Math.PI/-40f-(float)Math.PI*10f)/1f;
			PlayerSwingEffect(7.75f);

			attackNum3 = (int)(160f+(80f*hpLeft));
			attackNum++;

			if (attackNum > attackNum3 || attackNum4 == 0) {
				if (attackNum4 > (int)(5-(3*hpLeft))) { attackDone = true; return; }
				attackNum2 = Main.rand.Next(4);

				//attackNum2 = 0; //Testing
				attackNum5 = Main.rand.Next(6, 10);
				if (Main.rand.NextBool()) attackNum5 = Main.rand.Next(12, 16);
				//attackNum5 = 12;

				for (int i = 0; i < 21; i++) {
					Vector2 offset = new Vector2(i*115-1150, 1000);
					if (i != attackNum5) if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), ringPos-offset.RotatedBy(MathHelper.ToRadians(attackNum2*90)), Vector2.Zero, ModContent.ProjectileType<SaburRexStarofWrath>(), (int)(NPC.damage/4f), 0f, -1, attackNum2, attackNum3-120);
				}

				attackNum = 0;
				attackNum4++;
				//if (Main.rand.NextBool(3)) attackNum6++;
			}
		}
		private void PlayerSwingEffect(float swingSpeed) { //For any attacks that it should look like the sword swings like a player.
			NPC.ai[2] += MathHelper.ToRadians(swingSpeed); //Swings at the requested rate.

			if (NPC.ai[2] > MathHelper.ToRadians(125) && NPC.ai[2] < MathHelper.ToRadians(290)) { //Checks if it has gone too far
				NPC.ai[2] = MathHelper.ToRadians(290); //Reset position.
				SoundEngine.PlaySound(SoundID.Item1, NPC.position); //Sword swing sound
			}
		}
		private void UpdateFrame() { //Animation + general updates and checks
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
			if (NPC.ai[0] != 2 && NPC.ai[0] != 3 && !(NPC.ai[0] == 5 && attackNum == 0)) { //Don't automate the process during the Katana and Bee Keeper attacks. Also, sometimes the Cobalt Sword.
				if (Math.Abs(NPC.velocity.X) > 0.05f) {
					if (NPC.velocity.X < 0) NPC.direction = -1;
					else NPC.direction = 1;
				}
			}
			NPC.spriteDirection = NPC.direction;
			ringTotalRot += ringRotSpeed; //Rotate the boss ring.
			//Main.NewText(NPC.direction); //test

			if (init && !finale) for (int i = 0;  i < Main.maxPlayers; i++) {
				if ((Vector2.Distance(Main.player[i].Center, ringPos) > 750 && Vector2.Distance(Main.player[i].Center, ringPos) < 2000) || Main.player[i].HasBuff(BuffID.Shimmer)) {
					Main.player[i].AddBuff(ModContent.BuffType<Buffs.Debuffs.Dishonored>(), 2);

					//Possibly add later with visuals? Idk
					//if (init && NPC.ai[0] == 0f) //Leaving the arena is banned during the influx waver attack
					//	Main.player[i].AddBuff(BuffID.Electrified, 2);
				}
			}

			NPC.dontTakeDamage = !init; //No hitting early!

            hpLeft = (float)NPC.life/(float)NPC.lifeMax;

			attackTotalTime++;
        }
		private void NewAttack() {
			prevAttack = NPC.ai[0]; //Bans the recent attack from being chosen again.
			NPC.ai[0] = NPC.ai[1]; //Pick up sword Sabur is holding.

			//Determine new attack (testing)
			NPC.ai[1] = NPC.ai[0]; //Forces the while loop to run at least once
			while (NPC.ai[1] == NPC.ai[0] || NPC.ai[1] == prevAttack) NPC.ai[1] = Main.rand.Next(8);

			//NPC.ai[0] = 2f; //TESTING - force a certain attack.
			
			//Reset stats and rotation.
			attackTimer = 0;
			attackDone = false;
			attackNum = 0;
			NPC.ai[2] = MathHelper.ToRadians(290); //Sword swings start around here.
			attackTotalTime = 0;
			attackFloat = 0f;
			attackFloat2 = 0f;
			NPC.ai[3] = 0;
			attackNum2 = 0;
			attackNum3 = 0;
			attackNum4 = 0;
			attackNum5 = 0;
			attackNum6 = 0;
			attackNum7 = 0;
			attackNum8 = 0;
			attackNum9 = 0;
			attackFloat3 = 0f;
			attackFloat4 = 0f;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			int QBframe = (int)(Main.GameUpdateCount/5) % 4;
			Texture2D whiteTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Light");
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D borderTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Border");
			Texture2D guardianTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_DungeonGuardian");
			Texture2D queenBeeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_QueenBee" + QBframe);
			Texture2D greyArrowTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_GreyArrow");

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY); //For main
			Vector2 ringDrawPos = ringPos - screenPos + new Vector2(0f, NPC.gfxOffY); //Permanent pos for ring (see for loop below)

			//Color color = NPC.GetAlpha(drawColor);
			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			Vector2 whiteOrigin = new Vector2(whiteTexture.Width * 0.5f, whiteTexture.Height * 0.5f);
			Vector2 borderOrigin = new Vector2(borderTexture.Width * 0.5f, borderTexture.Height * 0.5f);
			Vector2 guardianOrigin = new Vector2(guardianTexture.Width * 0.5f, guardianTexture.Height * 0.5f);
			Vector2 QBOrigin = new Vector2(queenBeeTexture.Width * 0.5f, queenBeeTexture.Height * 0.5f);
			Vector2 GAOrigin = new Vector2(greyArrowTexture.Width * 0.5f, greyArrowTexture.Height * 0.5f);

			//Stolen from projectile code so that multiple frames can be drawn
			int frameHeight = texture.Height / 6;
			int spriteSheetOffset = frameHeight * (NPC.frame.Y/64);

			//Dungeon guardian draw for the bone sword attack
			if (NPC.ai[0] == 1f && MathHelper.ToDegrees(attackFloat) >= 13f && !finale) { //I seriously used NPC.ai[2] at first and wondered why this wasn't working...
				float guardianVisibility = (MathHelper.ToDegrees(attackFloat)-11.5f)/10f; //minValue is 0%, maxValue is 75% (0.75f)
				spriteBatch.Draw(guardianTexture, drawPos, null, Color.White*guardianVisibility, attackFloat2, guardianOrigin, 1.5f, SpriteEffects.None, 0);
			}

			//Queen Bee draw for the Bee Keeper attack
			if (NPC.ai[0] == 3f) {
				if (attackNum == 0) attackFloat += 0.05f;
				else attackFloat -= 0.05f;

				if (attackFloat > 0.5f) attackFloat = 0.5f;
				if (attackFloat < 0f) attackFloat = 0f;
			}
			if (NPC.ai[0] == 3f && attackNum3 == 1 && !finale) {
				SpriteEffects QBeffects = SpriteEffects.None;
				if (attackNum2 == -1) QBeffects = SpriteEffects.FlipHorizontally;
				spriteBatch.Draw(queenBeeTexture, drawPos, null, Color.White*attackFloat, 0f, QBOrigin, 1.5f, QBeffects, 0);
			}

			//Grey Arrow for the Cobalt Sword attack
			int total = attackNum2;
			if (attackNum2 == 21) total = 20;
			if (NPC.ai[0] == 5f) for (int i = 0; i < total; i++) {
				Color col = new Color(attackNum3, attackNum4, attackNum5);

				float shade = 1f;
				if (i+1 == attackNum2) shade = (float)(attackTimer%2)/2f;

				//float rot = attackFloat4 + MathHelper.Pi;
				//if (attackNum8 == -1) rot = -attackFloat4 + MathHelper.Pi;

				float rot = attackNum8*attackFloat4 + MathHelper.Pi;

				int dir = 1;
				if (rot < MathHelper.Pi || rot > MathHelper.TwoPi) dir = -1;
				//Main.NewText(rot);

				Vector2 newPos = new Vector2(attackFloat2, attackFloat3) - screenPos + new Vector2(0f, NPC.gfxOffY) - new Vector2(0, 36*i).RotatedBy(NPC.ai[2]*dir);

				if (i >= attackNum6) spriteBatch.Draw(greyArrowTexture, newPos, null, col*shade, rot, GAOrigin, 1.5f, SpriteEffects.None, 0);
			}

			//Tome man please explain why I'm dumb and have to manually set the main texture to be lower positioned but not the light sprite (160 is 2.5 frames)
            spriteBatch.Draw(texture, drawPos+new Vector2(0, 160), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, 0f, drawOrigin, NPC.scale, effects, 0); //Draw main boss

			int ringCount = 30;

			//Slowly transition away as he descends
			if (!init) {
				//Color amount = new Color(255, 255, 255); //255-255*((float)attackTimer/120f)
				spriteBatch.Draw(whiteTexture, drawPos, null, Color.White*(1f-(float)attackTimer/120f), 0f, whiteOrigin, NPC.scale, effects, 0); //Draw light for intro
				if (attackTimer < 180) ringCount = (int)(30*(attackTimer/180f));
			}
			else if (ringSpace < 750) ringSpace += 20; //250 to 750

			if (finale) {
				spriteBatch.Draw(whiteTexture, drawPos, null, Color.White*(0.9f+(float)Math.Sin(Main.GameUpdateCount/10f)/10f), 0f, whiteOrigin, NPC.scale, effects, 0); //Draw light for outro
			}

			//Draws the border (rainbow ring) of the boss.
			for (int j = 0; j < 10; j++) for (int i = 0; i < ringCount; i++) { //i*(360/ringCount) //old
				Vector2 borderPos = ringDrawPos - new Vector2(0, ringSpace).RotatedBy(MathHelper.ToRadians(i*12+ringTotalRot-(j*(1f-j*(0.03f*((ringSpace+250f)/500f-1f)))))); //Trust me otherwise it looks bad ;-; | isolation: j*(1f-j*0.03f)

				//Cool transition
				float alphaRing = 1f;
				if (i == ringCount - 1 && !init && attackTimer < 180) alphaRing = (attackTimer % 6 / 6f);
				if (finale) {
					alphaRing = (float)Math.Cos(Math.PI*attackTimer/90f)/2f + 0.5f; //attackTimer/90f;
					if (attackTimer > 90) alphaRing = 0f; //Just in case I change stuff.
					ringSpace = (int)(750*alphaRing);
				}

				spriteBatch.Draw(borderTexture, borderPos, null, Main.DiscoColor*alphaRing, 0f, borderOrigin, NPC.scale*(1f-0.1f*j), SpriteEffects.None, 0);
            }
			return false;
        }
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.SuperHealingPotion;
        }
        public override void OnKill() {
            if (Zylon.noHitSabur) Item.NewItem(NPC.GetSource_FromThis(), NPC.getRect(), ModContent.ItemType<Items.Swords.Excalipoor>());
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.SaburTrophy>(), 10));

			notExpertRule.OnSuccess(new CommonDrop(ModContent.ItemType<Items.Vanity.SaburMask>(), 7));
			notExpertRule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Boomerangs.AussieDagger>(), ModContent.ItemType<Items.Blowpipes.HollowKnife>(), ModContent.ItemType<Items.Wands.BladeTorrentStaff>(), ModContent.ItemType<Items.Minions.SwordigamStaff>()));
			notExpertRule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ModContent.ItemType<Items.Yoyos.TheRetractor>(), ModContent.ItemType<Items.Bows.Dirkbow>(), ModContent.ItemType<Items.Tomes.TaleoftheEverlastingBlade>(), ModContent.ItemType<Items.Whips.Snakesabre>()));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Materials.FantasticalFinality>(), 1, 10, 10));

			npcLoot.Add(notExpertRule);

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SaburBag>()));

			npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeables.Relics.SaburRelic>()));
			npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<Items.Pets.AncientGameController>(), 4));
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A sword-obsessed godlike wolf from another dimension who is so powerful that he can bend the original uses of his blades to his will.")
			});
		}
    }
}