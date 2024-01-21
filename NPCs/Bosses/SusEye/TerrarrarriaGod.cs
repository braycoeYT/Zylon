using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Chat;
using Terraria.Audio;

namespace Zylon.NPCs.Bosses.SusEye
{
	[AutoloadBossHead]
	public class TerrarrarriaGod : ModNPC
	{
		public override void SetStaticDefaults() {
			NPCID.Sets.MPAllowedEnemies[Type] = true;

			// DisplayName.SetDefault("Suspicious Looking Eye");
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}
        public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DemonEye);
			//NPC.value = 0f;
			NPC.aiStyle = NPCID.Retinazer;
			AnimationType = -1;
			NPC.lifeMax = 30000;
			NPC.damage = 311;
			NPC.defense = 0;
			NPC.noTileCollide = true;
			//NPC.color = Color.Aqua;
			NPC.boss = true;
			NPC.knockBackResist = 0f;
			NPC.value = 42069;
			NPC.netAlways = true;
        }
		public override void OnHitByItem(Player player, Item item, NPC.HitInfo hit, int damageDone)
		{
			if (damageDone > 99999) {
				NPC.life += damageDone;
				CombatText.NewText(NPC.getRect(), Color.LimeGreen, damageDone);
				if (NPC.life < 1)
					NPC.life = NPC.lifeMax;
			}
		}
		public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone) {
            if (projectile.type == ProjectileID.FinalFractal) damageDone /= 2;
        }
		/*public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
		}*/
		int Timer;

		bool chat1 = true;

		float attackTime;

		public override bool PreAI() {
			NPC.boss = true;
			if (Main.rand.NextBool(30)) NPC.color = new Color(Main.rand.Next(0, 255), Main.rand.Next(0, 255), Main.rand.Next(0, 255));
			Timer++;

			NPC.TargetClosest(true);

			if (Vector2.Distance(NPC.Center, Main.player[NPC.target].Center) > 1400) {
				NPC.velocity = Vector2.Normalize(NPC.Center - Main.player[NPC.target].Center)*-30f;
			}

            if (!Main.zenithWorld) { 
				Color messageColor = Color.DarkRed;
					string chat = "GET FIXED BOI!!!!!!!!!!!!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				NPC.active = false;
			}


				if (chat1)
				{
					Color messageColor = Color.Purple;
					string chat = "Terrarrarria God has awoken!";
					if (Main.netMode == NetmodeID.Server)
					{
						ChatHelper.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat1 = false;
				}
			
			attackTime += 2f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.875f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.75f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.625f))
				attackTime += 0.4f;	
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.5f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.325f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.25f))
				attackTime += 0.4f;
			if ((double)(NPC.life) < (double)(NPC.lifeMax * 0.125f))
				attackTime += 0.4f;
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
									{
										NPC.TargetClosest(true);
									}
									bool dead2 = Main.player[NPC.target].dead;
									float num376 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
									float num377 = NPC.position.Y + (float)NPC.height - 59f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
									float num378 = (float)Math.Atan2((double)num377, (double)num376) + 1.57f;
									if (num378 < 0f)
									{
										num378 += 6.283f;
									}
									else if ((double)num378 > 6.283)
									{
										num378 -= 6.283f;
									}
									float num379 = 0.1f;
									if (NPC.rotation < num378)
									{
										if ((double)(num378 - NPC.rotation) > 3.1415)
										{
											NPC.rotation -= num379;
										}
										else
										{
											NPC.rotation += num379;
										}
									}
									else if (NPC.rotation > num378)
									{
										if ((double)(NPC.rotation - num378) > 3.1415)
										{
											NPC.rotation += num379;
										}
										else
										{
											NPC.rotation -= num379;
										}
									}
									if (NPC.rotation > num378 - num379 && NPC.rotation < num378 + num379)
									{
										NPC.rotation = num378;
									}
									if (NPC.rotation < 0f)
									{
										NPC.rotation += 6.283f;
									}
									else if ((double)NPC.rotation > 6.283)
									{
										NPC.rotation -= 6.283f;
									}
									if (NPC.rotation > num378 - num379 && NPC.rotation < num378 + num379)
									{
										NPC.rotation = num378;
									}
									if (Main.rand.NextBool(5))
									{
										int num380 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_131D1_cp_0_cp_0 = Main.dust[num380];
										var_9_131D1_cp_0_cp_0.velocity.X = var_9_131D1_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_131F5_cp_0_cp_0 = Main.dust[num380];
										var_9_131F5_cp_0_cp_0.velocity.Y = var_9_131F5_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != NetmodeID.MultiplayerClient && !dead2 && NPC.timeLeft < 10)
									{
										int num;
										for (int num381 = 0; num381 < 200; num381 = num + 1)
										{
											if (num381 != NPC.whoAmI && Main.npc[num381].active && (Main.npc[num381].type == NPCID.Retinazer || Main.npc[num381].type == NPCID.Spazmatism) && Main.npc[num381].timeLeft - 1 > NPC.timeLeft)
											{
												NPC.timeLeft = Main.npc[num381].timeLeft - 1;
											}
											num = num381;
										}
									}
									if (dead2)
									{
										NPC.velocity.Y = NPC.velocity.Y - 0.04f;
										if (NPC.timeLeft > 10)
										{
											NPC.timeLeft = 10;
											return true;
										}
									}
									else if (NPC.ai[0] == 0f)
									{
										if (NPC.ai[1] == 0f)
										{
											float num382 = 7f;
											float num383 = 0.1f;
											if (Main.expertMode)
											{
												num382 = 8.25f;
												num383 = 0.115f;
											}
											int num384 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num384 = -1;
											}
											Vector2 vector40 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num385 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num384 * 300) - vector40.X;
											float num386 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector40.Y;
											float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
											float num388 = num387;
											num387 = num382 / num387;
											num385 *= num387;
											num386 *= num387;
											if (NPC.velocity.X < num385)
											{
												NPC.velocity.X = NPC.velocity.X + num383;
												if (NPC.velocity.X < 0f && num385 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num383;
												}
											}
											else if (NPC.velocity.X > num385)
											{
												NPC.velocity.X = NPC.velocity.X - num383;
												if (NPC.velocity.X > 0f && num385 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num383;
												}
											}
											if (NPC.velocity.Y < num386)
											{
												NPC.velocity.Y = NPC.velocity.Y + num383;
												if (NPC.velocity.Y < 0f && num386 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num383;
												}
											}
											else if (NPC.velocity.Y > num386)
											{
												NPC.velocity.Y = NPC.velocity.Y - num383;
												if (NPC.velocity.Y > 0f && num386 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num383;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 600f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											else if (NPC.position.Y + (float)NPC.height < Main.player[NPC.target].position.Y && num388 < 400f)
											{
												if (!Main.player[NPC.target].dead)
												{
													NPC.ai[3] += 1f;
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.9)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.7)
													{
														NPC.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.6)
													{
														NPC.ai[3] += 0.3f;
													}
												}
												
											}
										}
										else if (NPC.ai[1] == 1f)
										{
											NPC.rotation = num378;
											float num393 = 12f;
											if (Main.expertMode)
											{
												num393 = 15f;
											}
											Vector2 vector41 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num394 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector41.X;
											float num395 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector41.Y;
											float num396 = (float)Math.Sqrt((double)(num394 * num394 + num395 * num395));
											num396 = num393 / num396;
											NPC.velocity.X = num394 * num396;
											NPC.velocity.Y = num395 * num396;
											NPC.ai[1] = 2f;
										}
										else if (NPC.ai[1] == 2f)
										{
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 25f)
											{
												NPC.velocity.X = NPC.velocity.X * 0.96f;
												NPC.velocity.Y = NPC.velocity.Y * 0.96f;
												if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
												{
													NPC.velocity.X = 0f;
												}
												if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
												{
													NPC.velocity.Y = 0f;
												}
											}
											else
											{
												NPC.rotation = (float)Math.Atan2((double)NPC.velocity.Y, (double)NPC.velocity.X) - 1.57f;
											}
											if (NPC.ai[2] >= 70f)
											{
												NPC.ai[3] += 1f;
												NPC.ai[2] = 0f;
												NPC.target = 255;
												NPC.rotation = num378;
												if (NPC.ai[3] >= 4f)
												{
													NPC.ai[1] = 0f;
													NPC.ai[3] = 0f;
												}
												else
												{
													NPC.ai[1] = 1f;
												}
											}
										}
										if ((double)NPC.life < (double)NPC.lifeMax * 0.4)
										{
											NPC.ai[0] = 1f;
											NPC.ai[1] = 0f;
											NPC.ai[2] = 0f;
											NPC.ai[3] = 0f;
											NPC.netUpdate = true;
											return true;
										}
									}
									else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
									{
										if (NPC.ai[0] == 1f)
										{
											NPC.ai[2] += 0.005f;
											if ((double)NPC.ai[2] > 0.5)
											{
												NPC.ai[2] = 0.5f;
											}
										}
										else
										{
											NPC.ai[2] -= 0.005f;
											if (NPC.ai[2] < 0f)
											{
												NPC.ai[2] = 0f;
											}
										}
										NPC.rotation += NPC.ai[2];
										NPC.ai[1] += 1f;
										if (NPC.ai[1] == 100f)
										{
											NPC.ai[0] += 1f;
											NPC.ai[1] = 0f;
											if (NPC.ai[0] == 3f)
											{
												NPC.ai[2] = 0f;
											}
											else
											{
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
												int num;
												for (int num397 = 0; num397 < 2; num397 = num + 1)
												{
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num397;
												}
												for (int num398 = 0; num398 < 20; num398 = num + 1)
												{
													Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num398;
												}
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
											}
										}
										Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										NPC.velocity.X = NPC.velocity.X * 0.98f;
										NPC.velocity.Y = NPC.velocity.Y * 0.98f;
										if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
										{
											NPC.velocity.X = 0f;
										}
										if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
										{
											NPC.velocity.Y = 0f;
											return true;
										}
									}
									else
									{
										NPC.damage = (int)((double)NPC.defDamage * 1.5);
										NPC.defense = NPC.defDefense + 10;
										NPC.HitSound = SoundID.NPCHit4;
										if (NPC.ai[1] == 0f)
										{
											float num399 = 8f;
											float num400 = 0.15f;
											if (Main.expertMode)
											{
												num399 = 9.5f;
												num400 = 0.175f;
											}
											Vector2 vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
											float num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - 300f - vector42.Y;
											float num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
											num403 = num399 / num403;
											num401 *= num403;
											num402 *= num403;
											if (NPC.velocity.X < num401)
											{
												NPC.velocity.X = NPC.velocity.X + num400;
												if (NPC.velocity.X < 0f && num401 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num400;
												}
											}
											else if (NPC.velocity.X > num401)
											{
												NPC.velocity.X = NPC.velocity.X - num400;
												if (NPC.velocity.X > 0f && num401 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num400;
												}
											}
											if (NPC.velocity.Y < num402)
											{
												NPC.velocity.Y = NPC.velocity.Y + num400;
												if (NPC.velocity.Y < 0f && num402 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num400;
												}
											}
											else if (NPC.velocity.Y > num402)
											{
												NPC.velocity.Y = NPC.velocity.Y - num400;
												if (NPC.velocity.Y > 0f && num402 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num400;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 300f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.TargetClosest(true);
												NPC.netUpdate = true;
											}
											vector42 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											num401 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector42.X;
											num402 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector42.Y;
											NPC.rotation = (float)Math.Atan2((double)num402, (double)num401) - 1.57f;
											if (Main.netMode != NetmodeID.MultiplayerClient)
											{
												NPC.localAI[1] += 1f;
												if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
												{
													NPC.localAI[1] += 2f;
												}
												if (NPC.localAI[1] > 250f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
												{
													NPC.localAI[1] = 0f;
													float num404 = 8.5f;
													int num405 = 50; //25
													int num406 = 288;
													if (Main.expertMode)
													{
														num404 = 10f;
														num405 = 46; //46
													}
													num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
													num403 = num404 / num403;
													num401 *= num403;
													num402 *= num403;
													vector42.X += num401 * 15f;
													vector42.Y += num402 * 15f;
							int num407;
													if (Main.rand.NextBool(8)) num407 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector42.X, vector42.Y, num401, num402, num406, num405, 0f, Main.myPlayer, 0f, 0f);
													return true;
												}
											}
										}
										else
										{
											int num408 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num408 = -1;
											}
											float num409 = 8f;
											float num410 = 0.2f;
											if (Main.expertMode)
											{
												num409 = 9.5f;
												num410 = 0.25f;
											}
											Vector2 vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num411 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num408 * 340) - vector43.X;
											float num412 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
											float num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
											num413 = num409 / num413;
											num411 *= num413;
											num412 *= num413;
											if (NPC.velocity.X < num411)
											{
												NPC.velocity.X = NPC.velocity.X + num410;
												if (NPC.velocity.X < 0f && num411 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num410;
												}
											}
											else if (NPC.velocity.X > num411)
											{
												NPC.velocity.X = NPC.velocity.X - num410;
												if (NPC.velocity.X > 0f && num411 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num410;
												}
											}
											if (NPC.velocity.Y < num412)
											{
												NPC.velocity.Y = NPC.velocity.Y + num410;
												if (NPC.velocity.Y < 0f && num412 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num410;
												}
											}
											else if (NPC.velocity.Y > num412)
											{
												NPC.velocity.Y = NPC.velocity.Y - num410;
												if (NPC.velocity.Y > 0f && num412 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num410;
												}
											}
											vector43 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											num411 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector43.X;
											num412 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector43.Y;
											NPC.rotation = (float)Math.Atan2((double)num412, (double)num411) - 1.57f;
											if (Main.netMode != NetmodeID.MultiplayerClient)
											{
												NPC.localAI[1] += 1f;
												if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
												{
													NPC.localAI[1] += 0.5f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
												{
													NPC.localAI[1] += 0.75f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
												{
													NPC.localAI[1] += 1f;
												}
												if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
												{
													NPC.localAI[1] += 1.5f;
												}
												if (Main.expertMode)
												{
													NPC.localAI[1] += 1.5f;
												}
												if (NPC.localAI[1] > 300f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
												{
													NPC.localAI[1] = 0f;
													float num414 = 9f;
													int num415 = 36; //18
													int num416 = 288;
													if (Main.expertMode)
													{
														num415 = 34; //17
													}
													num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
													num413 = num414 / num413;
													num411 *= num413;
													num412 *= num413;
													vector43.X += num411 * 15f;
													vector43.Y += num412 * 15f;
							int num417;
													if (Main.rand.NextBool(8)) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector43.X, vector43.Y, num411, num412, num416, num415, 0f, Main.myPlayer, 0f, 0f);
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 180f)
											{
												NPC.ai[1] = 0f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.TargetClosest(true);
												NPC.netUpdate = true;
												return true;
											}
										}
									}
									if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
									{
										NPC.TargetClosest(true);
									}
									bool dead3 = Main.player[NPC.target].dead;
									float num418 = NPC.position.X + (float)(NPC.width / 2) - Main.player[NPC.target].position.X - (float)(Main.player[NPC.target].width / 2);
									float num419 = NPC.position.Y + (float)NPC.height - 59f - Main.player[NPC.target].position.Y - (float)(Main.player[NPC.target].height / 2);
									float num420 = (float)Math.Atan2((double)num419, (double)num418) + 1.57f;
									if (num420 < 0f)
									{
										num420 += 6.283f;
									}
									else if ((double)num420 > 6.283)
									{
										num420 -= 6.283f;
									}
									float num421 = 0.15f;
									if (NPC.rotation < num420)
									{
										if ((double)(num420 - NPC.rotation) > 3.1415)
										{
											NPC.rotation -= num421;
										}
										else
										{
											NPC.rotation += num421;
										}
									}
									else if (NPC.rotation > num420)
									{
										if ((double)(NPC.rotation - num420) > 3.1415)
										{
											NPC.rotation += num421;
										}
										else
										{
											NPC.rotation -= num421;
										}
									}
									if (NPC.rotation > num420 - num421 && NPC.rotation < num420 + num421)
									{
										NPC.rotation = num420;
									}
									if (NPC.rotation < 0f)
									{
										NPC.rotation += 6.283f;
									}
									else if ((double)NPC.rotation > 6.283)
									{
										NPC.rotation -= 6.283f;
									}
									if (NPC.rotation > num420 - num421 && NPC.rotation < num420 + num421)
									{
										NPC.rotation = num420;
									}
									if (Main.rand.NextBool(5))
									{
										int num422 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + (float)NPC.height * 0.25f), NPC.width, (int)((float)NPC.height * 0.5f), DustID.Blood, NPC.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_15364_cp_0_cp_0 = Main.dust[num422];
										var_9_15364_cp_0_cp_0.velocity.X = var_9_15364_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_15388_cp_0_cp_0 = Main.dust[num422];
										var_9_15388_cp_0_cp_0.velocity.Y = var_9_15388_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != NetmodeID.MultiplayerClient && !dead3 && NPC.timeLeft < 10)
									{
										int num;
										for (int num423 = 0; num423 < 200; num423 = num + 1)
										{
											if (num423 != NPC.whoAmI && Main.npc[num423].active && (Main.npc[num423].type == NPCID.Retinazer || Main.npc[num423].type == NPCID.Spazmatism) && Main.npc[num423].timeLeft - 1 > NPC.timeLeft)
											{
												NPC.timeLeft = Main.npc[num423].timeLeft - 1;
											}
											num = num423;
										}
									}
									if (dead3)
									{
										NPC.velocity.Y = NPC.velocity.Y - 0.04f;
										if (NPC.timeLeft > 10)
										{
											NPC.timeLeft = 10;
											return true;
										}
									}
									else if (NPC.ai[0] == 0f)
									{
										if (NPC.ai[1] == 0f)
										{
											NPC.TargetClosest(true);
											float num424 = 12f;
											float num425 = 0.4f;
											int num426 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num426 = -1;
											}
											Vector2 vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num427 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num426 * 400) - vector44.X;
											float num428 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
											float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
											num429 = num424 / num429;
											num427 *= num429;
											num428 *= num429;
											if (NPC.velocity.X < num427)
											{
												NPC.velocity.X = NPC.velocity.X + num425;
												if (NPC.velocity.X < 0f && num427 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num425;
												}
											}
											else if (NPC.velocity.X > num427)
											{
												NPC.velocity.X = NPC.velocity.X - num425;
												if (NPC.velocity.X > 0f && num427 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num425;
												}
											}
											if (NPC.velocity.Y < num428)
											{
												NPC.velocity.Y = NPC.velocity.Y + num425;
												if (NPC.velocity.Y < 0f && num428 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num425;
												}
											}
											else if (NPC.velocity.Y > num428)
											{
												NPC.velocity.Y = NPC.velocity.Y - num425;
												if (NPC.velocity.Y > 0f && num428 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num425;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 600f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											else
											{
												if (!Main.player[NPC.target].dead)
												{
													NPC.ai[3] += 1f;
													if (Main.expertMode && (double)NPC.life < (double)NPC.lifeMax * 0.8)
													{
														NPC.ai[3] += 0.6f;
													}
												}
											}
										}
										if ((double)NPC.life < (double)NPC.lifeMax * 0.4)
										{
											NPC.ai[0] = 1f;
											NPC.ai[1] = 0f;
											NPC.ai[2] = 0f;
											NPC.ai[3] = 0f;
											NPC.netUpdate = true;
											return true;
										}
									}
									else if (NPC.ai[0] == 1f || NPC.ai[0] == 2f)
									{
										if (NPC.ai[0] == 1f)
										{
											NPC.ai[2] += 0.005f;
											if ((double)NPC.ai[2] > 0.5)
											{
												NPC.ai[2] = 0.5f;
											}
										}
										else
										{
											NPC.ai[2] -= 0.005f;
											if (NPC.ai[2] < 0f)
											{
												NPC.ai[2] = 0f;
											}
										}
										NPC.rotation += NPC.ai[2];
										NPC.ai[1] += 1f;
										if (NPC.ai[1] == 100f)
										{
											NPC.ai[0] += 1f;
											NPC.ai[1] = 0f;
											if (NPC.ai[0] == 3f)
											{
												NPC.ai[2] = 0f;
											}
											else
											{
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
												int num;
												for (int num438 = 0; num438 < 2; num438 = num + 1)
												{
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num438;
												}
												for (int num439 = 0; num439 < 20; num439 = num + 1)
												{
													Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num439;
												}
												SoundEngine.PlaySound(SoundID.Item16, NPC.position);
											}
										}
										Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										NPC.velocity.X = NPC.velocity.X * 0.98f;
										NPC.velocity.Y = NPC.velocity.Y * 0.98f;
										if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
										{
											NPC.velocity.X = 0f;
										}
										if ((double)NPC.velocity.Y > -0.1 && (double)NPC.velocity.Y < 0.1)
										{
											NPC.velocity.Y = 0f;
											return true;
										}
									}
									else
									{
										NPC.HitSound = SoundID.NPCHit4;
										NPC.damage = (int)((double)NPC.defDamage * 1.5);
										NPC.defense = NPC.defDefense + 18;
										if (NPC.ai[1] == 0f)
										{
											float num440 = 4f;
											float num441 = 0.1f;
											int num442 = 1;
											if (NPC.position.X + (float)(NPC.width / 2) < Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width)
											{
												num442 = -1;
											}
											Vector2 vector46 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
											float num443 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) + (float)(num442 * 180) - vector46.X;
											float num444 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector46.Y;
											float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
											if (Main.expertMode)
											{
												if (num445 > 300f)
												{
													num440 += 0.5f;
												}
												if (num445 > 400f)
												{
													num440 += 0.5f;
												}
												if (num445 > 500f)
												{
													num440 += 0.55f;
												}
												if (num445 > 600f)
												{
													num440 += 0.55f;
												}
												if (num445 > 700f)
												{
													num440 += 0.6f;
												}
												if (num445 > 800f)
												{
													num440 += 0.6f;
												}
											}
											num445 = num440 / num445;
											num443 *= num445;
											num444 *= num445;
											if (NPC.velocity.X < num443)
											{
												NPC.velocity.X = NPC.velocity.X + num441;
												if (NPC.velocity.X < 0f && num443 > 0f)
												{
													NPC.velocity.X = NPC.velocity.X + num441;
												}
											}
											else if (NPC.velocity.X > num443)
											{
												NPC.velocity.X = NPC.velocity.X - num441;
												if (NPC.velocity.X > 0f && num443 < 0f)
												{
													NPC.velocity.X = NPC.velocity.X - num441;
												}
											}
											if (NPC.velocity.Y < num444)
											{
												NPC.velocity.Y = NPC.velocity.Y + num441;
												if (NPC.velocity.Y < 0f && num444 > 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y + num441;
												}
											}
											else if (NPC.velocity.Y > num444)
											{
												NPC.velocity.Y = NPC.velocity.Y - num441;
												if (NPC.velocity.Y > 0f && num444 < 0f)
												{
													NPC.velocity.Y = NPC.velocity.Y - num441;
												}
											}
											NPC.ai[2] += 1f;
											if (NPC.ai[2] >= 400f)
											{
												NPC.ai[1] = 1f;
												NPC.ai[2] = 0f;
												NPC.ai[3] = 0f;
												NPC.target = 255;
												NPC.netUpdate = true;
											}
											if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
											{
												NPC.localAI[2] += 1f;
												if (NPC.localAI[2] > 22f)
												{
													NPC.localAI[2] = 0f;
													SoundEngine.PlaySound(SoundID.Item34, NPC.position);
												}
												if (Main.netMode != NetmodeID.MultiplayerClient)
												{
													NPC.localAI[1] += 1f;
													if ((double)NPC.life < (double)NPC.lifeMax * 0.75)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.5)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.25)
													{
														NPC.localAI[1] += 1f;
													}
													if ((double)NPC.life < (double)NPC.lifeMax * 0.1)
													{
														NPC.localAI[1] += 2f;
													}
													if (NPC.localAI[1] > 200f)
													{
														NPC.localAI[1] = 0f;
														float num446 = 6f;
														int num447 = 60; //30
														if (Main.expertMode)
														{
															num447 = 54; //27
														}
														int num448 = 348;
														vector46 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
														num443 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector46.X;
														num444 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector46.Y;
														num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
														num445 = num446 / num445;
														num443 *= num445;
														num444 *= num445;
														num444 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num443 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num444 += NPC.velocity.Y * 0.5f;
														num443 += NPC.velocity.X * 0.5f;
														vector46.X -= num443 * 1f;
														vector46.Y -= num444 * 1f;
								int num449;
														if (Main.rand.NextBool(8)) num449 = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector46.X, vector46.Y, num443, num444, num448, num447, 0f, Main.myPlayer, 0f, 0f);
														return true;
													}
												}
											}
										}
										
									}
									if (attackTime >= 60f)
												{
													attackTime = 0f;
													Vector2 vector40 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
													float num385 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector40.X;
													float num386 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector40.Y;
														float num389 = 9f;
														int num390 = 40; //20
														int num391 = 348;
														if (Main.expertMode)
														{
															num389 = 10.5f;
															num390 = 38; //19
														}
														float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
														num387 = num389 / num387;
														num385 *= num387;
														num386 *= num387;
														num385 += (float)Main.rand.Next(-40, 41) * 0.08f;
														num386 += (float)Main.rand.Next(-40, 41) * 0.08f;
														vector40.X += num385 * 15f;
														vector40.Y += num386 * 15f;
													if (Main.rand.NextBool(8)) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector40.X, vector40.Y, num385, num386, num391, num390, 0f, Main.myPlayer, 0f, 0f);
													NPC.ai[3] = 0f;
													Vector2 vector44 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
													float num427 = Main.player[NPC.target].position.X + (float)(Main.player[NPC.target].width / 2) - vector44.X;
													float num428 = Main.player[NPC.target].position.Y + (float)(Main.player[NPC.target].height / 2) - vector44.Y;
													if (Main.netMode != NetmodeID.MultiplayerClient)
													{
														float num430 = 8f;
														int num431 = 50; //25
														int num432 = 467;
														if (Main.expertMode)
														{
															num430 = 9f;
															num431 = 44; //22
														}
														float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
														num429 = num430 / num429;
														num427 *= num429;
														num428 *= num429;
														num427 += (float)Main.rand.Next(-40, 41) * 0.05f;
														num428 += (float)Main.rand.Next(-40, 41) * 0.05f;
														vector44.X += num427 * 4f;
														vector44.Y += num428 * 4f;
														if (Main.rand.NextBool(8)) Projectile.NewProjectile(NPC.GetSource_FromThis(), vector44.X, vector44.Y, num427, num428, num432, num431, 0f, Main.myPlayer, 0f, 0f);
													}
												}
									return true;
		}
		public override void HitEffect(NPC.HitInfo hit) {
			for (int i = 0; i < 2; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}