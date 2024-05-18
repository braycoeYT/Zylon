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
using Zylon.Projectiles.Whips;

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
		}
        public override void SetDefaults() {
            NPC.width = 58;
			NPC.height = 64;
			NPC.damage = 130;
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
			Music = MusicID.Boss1;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = (int)(500000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
			NPC.damage = 260;
			NPC.value = Item.buyPrice(7, 50);
			if (Main.masterMode) {
				NPC.lifeMax = (int)(650000*balance*bossAdjustment*ModContent.GetInstance<ZylonConfig>().bossHpMult);
				NPC.damage = 390;
            }
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot) {
			if (NPC.ai[0] == 0 && NPC.ai[3] == 1) return false; //See influx weaver code - prevent frustration.
            return true;
        }
        public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers) {
            if (projectile.type == ProjectileID.FinalFractal) modifiers.FinalDamage *= 0.66f; //I wanted to unnerf Zenith a little but not let it obliterate the mod's final boss
        }
        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers) {
            modifiers.SetMaxDamage(9999); //Anticheat + jrpg reference
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
        public override void AI() { //ai0 - current attack | ai1 - next attack | ai2 - current rotation | ai3 - other important communication w/ sword proj

			Zylon.hasFoughtSabur = true; //REMOVE WHEN BOSS FINISHED - JUST TO SKIP DIALOGUE

			NPC.TargetClosest();
			target = Main.player[NPC.target];
			ZylonGlobalNPC.saburBoss = NPC.whoAmI;

			if (!init) { //Sets up two floating sword projectiles + white light intro + dialogue
				attackTimer++; //Intro lasts two seconds

				ringRotSpeed = 0.5f; //Sets rotation speed of the rainbow ring.

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
			if (attackTimer >= 20+(int)(20*hpLeft)+normal && Main.netMode != NetmodeID.MultiplayerClient && attackTimer < 370+(int)(200*hpLeft)) {
				if (attackTotalTime <= 400+(int)(200*hpLeft)-30) //Decreases the amount of UFOs that appear in the next attack to reduce frustration
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(Main.rand.Next(-200, 201), Main.rand.Next(0, 50)), Vector2.Zero, ModContent.ProjectileType<SaburRexMartianSaucer>(), (int)(NPC.damage*0.15f), 0f);
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
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexBoneProj>(), (int)(NPC.damage*0.18f), 0f);
					}
					if (attackNum3 > 60) { //Attack over, reset variables
						attackNum2 = 0;
						attackNum3 = 0;
					}
				}

				//Bone projectile from outside ring

				if (attackNum5 > 3) {
					attackNum4++;
					if (attackNum4 > 150+(int)(45*hpLeft)) attackDone = true;
					return;
				}

				if (attackNum4 > 240) { //og 180
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int i = -800; i < 801; i += 200+(int)(24*hpLeft)) {
						Vector2 bonePos = ringPos - new Vector2(i, 850).RotatedBy(MathHelper.ToRadians(attackNum5*90)); //(i, Main.rand.Next(800, 901)) //idk if I want a uniform wall or a randomized one
						Projectile.NewProjectile(NPC.GetSource_FromThis(), bonePos, new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(attackNum5*90)), ModContent.ProjectileType<SaburRexBoneProjOutside>(), (int)(NPC.damage*0.18f), 0f);
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
			if (attackTotalTime == 1) attackNum5 = (int)(10+(30*hpLeft));
			if (attackTotalTime < attackNum5) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.RedTorch);
				dust.velocity = new Vector2(0, -3).RotatedBy(MathHelper.TwoPi*(attackTotalTime/attackNum5));
				dust.noGravity = true;
				dust.scale = 2f;
				return; //Giving time for players to prepare, but they won't listen of course.
			} //It takes until at least the third attempt for them to integrate this dust sequence into their nightmares. Happy dreaming, players!
			else if (attackTotalTime < 40) attackNum5 = 0;
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
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(0, 48).RotatedBy(attackFloat), new Vector2(0, 5).RotatedBy(attackFloat), ModContent.ProjectileType<SaburRexKatanaDuplicate>(), (int)(NPC.damage*0.2f), 0f, -1, ringPos.X, ringPos.Y, attackNum4);
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
						NPC.velocity = NPC.DirectionTo(target.Center)*(45f-(12f*hpLeft)); //og 45 - 15
					}
				}
				else if (attackTimer < 45) {
					NPC.direction = attackNum; //Don't allow him to flip directions while dashing.
					NPC.velocity *= 0.94f; //og 0.96
	
					//Katana duplicates
					if (Main.netMode != NetmodeID.MultiplayerClient && (attackTimer % (2+(int)(3*hpLeft)) == 0) && attackTimer < (50+(int)(25*hpLeft))) {
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-3f, 3f))), ModContent.ProjectileType<SaburRexKatanaDuplicate>(), (int)(NPC.damage*0.2f), 0f, -1, ringPos.X, ringPos.Y);
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

			//Honeypot projectiles
			attackNum6++;
			if (attackNum6 > 90+(int)(180*hpLeft)) {
				attackNum6 = 0;
				if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Bosses.SaburRex.SaburRexHoneyPot>(), (int)(NPC.damage/3), 0f, -1, NPC.target, hpLeft);
			}
		}
		private void Tizona() {

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
			if (NPC.ai[0] != 2 && NPC.ai[0] != 3) { //Don't automate the process during the Katana and Bee Keeper attacks.
				if (Math.Abs(NPC.velocity.X) > 0.05f) {
					if (NPC.velocity.X < 0) NPC.direction = -1;
					else NPC.direction = 1;
				}
			}
			NPC.spriteDirection = NPC.direction;
			ringTotalRot += ringRotSpeed; //Rotate the boss ring.
			//Main.NewText(NPC.direction); //test

			if (init) for (int i = 0;  i < Main.maxPlayers; i++) {
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
			while (NPC.ai[1] == NPC.ai[0] || NPC.ai[1] == prevAttack) NPC.ai[1] = Main.rand.Next(5);

			NPC.ai[0] = 3f; //TESTING - force a certain attack.
			
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
			attackFloat3 = 0f;
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			int QBframe = (int)(Main.GameUpdateCount/5) % 4;
			Texture2D whiteTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Light");
			Texture2D texture = TextureAssets.Npc[Type].Value;
			Texture2D borderTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_Border");
			Texture2D guardianTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_DungeonGuardian");
			Texture2D queenBeeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_QueenBee" + QBframe);

			Vector2 drawPos = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY); //For main
			Vector2 ringDrawPos = ringPos - screenPos + new Vector2(0f, NPC.gfxOffY); //Permanent pos for ring (see for loop below)

			//Color color = NPC.GetAlpha(drawColor);
			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			Vector2 whiteOrigin = new Vector2(whiteTexture.Width * 0.5f, whiteTexture.Height * 0.5f);
			Vector2 borderOrigin = new Vector2(borderTexture.Width * 0.5f, borderTexture.Height * 0.5f);
			Vector2 guardianOrigin = new Vector2(guardianTexture.Width * 0.5f, guardianTexture.Height * 0.5f);
			Vector2 QBOrigin = new Vector2(queenBeeTexture.Width * 0.5f, queenBeeTexture.Height * 0.5f);

			//Stolen from projectile code so that multiple frames can be drawn
			int frameHeight = texture.Height / 6;
			int spriteSheetOffset = frameHeight * (NPC.frame.Y/64);

			//Dungeon guardian draw for the bone sword attack
			if (NPC.ai[0] == 1f && MathHelper.ToDegrees(attackFloat) >= 13f) { //I seriously used NPC.ai[2] at first and wondered why this wasn't working...
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
			if (NPC.ai[0] == 3f && attackNum3 == 1) {
				SpriteEffects QBeffects = SpriteEffects.None;
				if (attackNum2 == -1) QBeffects = SpriteEffects.FlipHorizontally;
				spriteBatch.Draw(queenBeeTexture, drawPos, null, Color.White*attackFloat, 0f, QBOrigin, 1.5f, QBeffects, 0);
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
			else if (ringSpace < 750) ringSpace += 20;

			//Draws the border (rainbow ring) of the boss.
			for (int i = 0; i < ringCount; i++) { //i*(360/ringCount) //old
				Vector2 borderPos = ringDrawPos - new Vector2(0, ringSpace).RotatedBy(MathHelper.ToRadians(i*12+ringTotalRot));

				//Cool transition
				float alphaRing = 1f;
				if (i == ringCount - 1 && !init && attackTimer < 180) alphaRing = (attackTimer % 6 / 6f);

				spriteBatch.Draw(borderTexture, borderPos, null, Main.DiscoColor*alphaRing, 0f, borderOrigin, NPC.scale, SpriteEffects.None, 0);
            }
			return false;
        }
        public override void BossLoot(ref string name, ref int potionType) {
            potionType = ItemID.SuperHealingPotion;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A sword-obsessed godlike wolf from another dimension who is so powerful that he can bend the original uses of his blades to his will.")
			});
		}
    }
}