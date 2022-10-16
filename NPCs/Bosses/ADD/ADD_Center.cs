using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
	[AutoloadBossHead]
    public class ADD_Center : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Diskite Director");
            //Main.npcFrameCount[NPC.type] = 2;
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				CustomTexturePath = "Zylon/NPCs/Bosses/ADD/ADD_Bestiary",
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
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
        }
        public override void SetDefaults() {
            NPC.width = 88;
			NPC.height = 88;
			NPC.damage = 26;
			NPC.defense = 10;
			NPC.lifeMax = 1800;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = 40000;
			NPC.aiStyle = -1; //22
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.boss = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 2600 + ((numPlayers - 1) * 1200);
			NPC.damage = 43;
			NPC.value = 80000;
        }
        public override bool? CanBeHitByItem(Player player, Item item) {
			if (finalAtk && !finalAtk2) return false;
            return null;
        }
        public override bool? CanBeHitByProjectile(Projectile projectile) {
            if (finalAtk && !finalAtk2) return false;
            return null;
		}
        public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life > 0) {
				for (int i = 0; i < 3; i++) {
					Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.DiskiteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
					dust.noGravity = true;
				}
			}
			else for (int i = 0; i < 30; i++) {
				Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, ModContent.DustType<Dusts.DiskiteDust>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
				dust.noGravity = true;
			}
			if (NPC.life < 0 && Main.expertMode && !finalAtk) {
				NPC.life = 1;
				finalAtk = true;
				NPC.dontTakeDamage = true;
			}
			else if (NPC.life < 0) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-1, 1), 0), ModContent.GoreType<Gores.Bosses.ADD.ADDCenterDeath>());
		}
		int preTimer;
		int Timer;
		int attack;
		int attackTimer;
		int attackMax;
		int attackPrev;
		int attackInt;
		int flee;
		float crazyLaser = 1.25f;
		bool attackDone = true;
		bool init;
		bool phase;
		bool finalAtk;
		bool finalAtk2;
		bool catchUp;
		Vector2 atkVector;
		Vector2 prePos;
		Player target;
        public override bool PreAI() {
			if (finalAtk) {
				if (Main.player[NPC.target].statLife < 1 || Main.dayTime) {
					NPC.TargetClosest(true);
					if (Main.player[NPC.target].statLife < 1 || Main.dayTime) {
						if (flee == 0)
						flee++;
					}
					else
					flee = 0;
					if (flee > 0) NPC.velocity.Y = 10;
				}
				if (!target.ZoneDesert && !target.ZoneUndergroundDesert) NPC.dontTakeDamage = true;
				else NPC.dontTakeDamage = false;
				NPC.lifeMax = 400;
				NPC.defense = 15;
				preTimer++;
				if (preTimer < 59) NPC.velocity /= 2;
				if (preTimer < 59 && !finalAtk2) NPC.life = 1;
				else if (!finalAtk2) NPC.life += 3;
				if (NPC.life >= NPC.lifeMax) {
					finalAtk2 = true;
					NPC.life = NPC.lifeMax;
                }
				if (preTimer == 1) CombatText.NewText(NPC.getRect(), Color.Red, "SELF-DESTRUCT ACTIVATED!", true);
				if (preTimer < 59)
                {
					if (flee >= 1) {
                flee++;
                NPC.velocity.Y = 10f;
                if (flee >= 450)
                    NPC.active = false;
            }
					return false;
                }
				if (preTimer % 5 == 0) Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-18, 18), Main.rand.NextFloat(-6, -12)), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteShrapnelHostile>(), (int)(NPC.damage*0.45f), 0f);
				if (preTimer % 15 == 0) {
					prePos = NPC.Center - new Vector2(44, 44);
			SoundEngine.PlaySound(SoundID.Item14, prePos);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++) {
				int dustIndex = Dust.NewDust(new Vector2(prePos.X, prePos.Y), NPC.width, NPC.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 80; i++) {
				int dustIndex = Dust.NewDust(new Vector2(prePos.X, prePos.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(prePos.X, prePos.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			// Large Smoke Gore spawn
			for (int g = 0; g < 2; g++) {
				int goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)prePos.X, (int)prePos.Y), new Vector2(prePos.X + (float)(NPC.width / 2) - 24f, prePos.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)prePos.X, (int)prePos.Y), new Vector2(prePos.X + (float)(NPC.width / 2) - 24f, prePos.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)prePos.X, (int)prePos.Y), new Vector2(prePos.X + (float)(NPC.width / 2) - 24f, prePos.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)prePos.X, (int)prePos.Y), new Vector2(prePos.X + (float)(NPC.width / 2) - 24f, prePos.Y + (float)(NPC.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
                }
			if (preTimer % 10 == 0) {
					crazyLaser *= -1;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0, -8).RotatedBy(MathHelper.ToRadians(preTimer*crazyLaser)), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDLaser2>(), NPC.damage / 2, 0f);
				}
			NPC.dontTakeDamage = false;
				if (!finalAtk2) return false;
				if (preTimer % 120 < 60) {
					Vector2 speed = NPC.Center - target.Center;
					speed.Normalize();
					speed *= -5f;
					NPC.velocity += speed;
					NPC.velocity /= 2;
				}
				else if (preTimer % 30 == 0) {
					Vector2 speed = NPC.Center - target.Center - new Vector2(Main.rand.Next(-200, 200), Main.rand.Next(-200, 200));
					speed.Normalize();
					speed *= -20f;
					NPC.velocity = speed;
                }
				else NPC.velocity *= 0.975f;

				if (!target.ZoneDesert && !target.ZoneUndergroundDesert)
				NPC.dontTakeDamage = true;

				if (flee >= 1) {
                flee++;
                NPC.velocity.Y = 10f;
                if (flee >= 450)
                    NPC.active = false;
			}
            }
            return !finalAtk;
        }
        public override void AI() {
			Timer++;
			if (!init) {
				if (NPC.ai[0] == 0)
					NPC.active = false;
				NPC.ai[0] = 0f;
				init = true;
            }
			NPC.TargetClosest();
			target = Main.player[NPC.target];
            ZylonGlobalNPC.diskiteBoss = NPC.whoAmI;
			/*if (NPC.CountNPCS(ModContent.NPCType<ADD_SideTop>()) > 0 || NPC.CountNPCS(ModContent.NPCType<ADD_SideBottom>()) > 0) { 
				NPC.dontTakeDamage = true;
				phase = false;
			}
			else {
				NPC.dontTakeDamage = false;
				phase = true;
            }
			if (!target.ZoneDesert && !target.ZoneUndergroundDesert) {
				NPC.dontTakeDamage = true;
			}*/

			if (Main.player[NPC.target].statLife < 1 || Main.dayTime)
			{
				NPC.TargetClosest(true);
				if (Main.player[NPC.target].statLife < 1 || Main.dayTime) {
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}

			/*if (Math.Abs(NPC.Center.X - target.Center.X) + Math.Abs(NPC.Center.Y - target.Center.Y) > 400 && (attackDone == true && phase == true) || (Timer > 120 && phase == false && attack != 2)) {
				attack = 99;
            }*/

			if (!(attack == 99 && attackDone == false) && Timer < 180) {
				Vector2 speed = NPC.Center - target.Center;
				speed.Normalize();
				if (Main.expertMode) speed *= -4.5f;
				else speed *= -4f;
				if (attack == 1 && attackDone == false)
					NPC.velocity /= 2;
				NPC.velocity += speed;
				NPC.velocity /= 2;
            }
			if ((attack == 4 && Timer > 180 && attackTimer % 70 <= 30) || ((attack == 5 || attack == 6) && Timer > 180)) { //add atk5 and make the laser ring reverse in phase 2
				Vector2 speed = NPC.Center - target.Center; //atk6 = aim at player
				speed.Normalize();
				if (Main.expertMode) speed *= -4.5f;
				else speed *= -4f;
				if (attack == 1 && attackDone == false)
					NPC.velocity /= 2;
				NPC.velocity += speed;
				NPC.velocity /= 2;
            }

			if (Timer <= 180) {
				NPC.ai[1] = 0;
				if (Timer == 180) {
					attackTimer = 0;
					attackMax = 6;
					if (phase) attackMax = 7;
					while (attack == attackPrev)
						attack = Main.rand.Next(1, attackMax);
					attackTimer = 0;
					attackDone = false;
					attackInt = 0;
					if (attack == 6 && NPC.CountNPCS(ModContent.NPCType<SupportDiskite>()) > 0)
						while (attack == 6 || attack == attackPrev)
							attack = Main.rand.Next(1, attackMax);
					attackPrev = attack;
					//attack = 6;
                }
				if (phase && Timer < 100 + (int)(80*NPC.life/NPC.lifeMax) - 1) Timer = 100 + (int)(80*NPC.life/NPC.lifeMax) - 1;
            }
			else {
				/*if (attack == 1) {
					attackTimer++;
					if ((Main.expertMode && attackTimer % 20 == 0) || (!Main.expertMode && attackTimer % 30 == 0))
						Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Normalize(NPC.Center - (Main.player[NPC.target].Center - new Vector2(0, 150))) * -36f, ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDSandBall>(), (int)(NPC.damage * 0.3f), 0f, 255, NPC.target);
					//if (attackTimer > 179) {
					//	attackDone = true;
					//	attackTimer = 0;
                    //}
				}*/
				if (attack == 1) {
					attackTimer++;
					if (attackTimer < 15)
						NPC.velocity *= 0.975f;
					else if (attackTimer == 15) {
						atkVector = NPC.Center - target.Center;
						atkVector.Normalize();
						if (Main.expertMode) atkVector *= -18f;
						else atkVector *= -15f;
						if (phase) atkVector *= 1.25f - (0.25f*(NPC.life/NPC.lifeMax));
						NPC.velocity = atkVector;
					}
					else if (attackTimer < 60) {
						NPC.velocity *= 0.975f;
                    }
					else {
						//attackDone = true;
						attackTimer = 0;
						atkVector = new Vector2(0, 0);
                    }
				}
				else if (attack == 2) {
					attackTimer++;
					if (attackTimer == 1) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<ADD_LaserEye2>());
					if (attackTimer < 30)
						NPC.velocity *= 0.95f;
					else NPC.velocity = new Vector2();
					NPC.ai[1] = 1;
					if (Timer == 419) NPC.ai[1] = 0;
                }
				else if (attack == 3) {
					attackTimer++;
					if (attackTimer < 15)
						NPC.velocity *= 0.975f;
					else if (attackTimer == 15) {
						attackInt++;
						atkVector = NPC.Center - target.Center;
						if (attackInt % 2 == 0) atkVector -= new Vector2(0, 200);
						else atkVector -= new Vector2(0, -200);
						atkVector.Normalize();
						if (Main.expertMode) atkVector *= -20.5f;
						else atkVector *= -17f;
						if (phase) atkVector *= 1.25f - (0.25f*(NPC.life/NPC.lifeMax));
						NPC.velocity = atkVector;
					}
					else if (attackTimer < 60) {
						NPC.velocity *= 0.975f;
                    }
					else {
						//attackDone = true;
						attackTimer = 0;
						atkVector = new Vector2(0, 0);
                    }
				}
				else if (attack == 4) {
					attackTimer++;
					if (attackTimer % 70 > 30 && attackTimer % 70 < 55)
						NPC.velocity *= 0.975f;
					if (attackTimer % 70 >= (30 + (int)(20*NPC.life/NPC.lifeMax)) && attackTimer % 3 <= 1) {
						if (target.Center.X < NPC.Center.X) Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-12, 6), Main.rand.NextFloat(-6, -9)), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteShrapnelHostile>(), (int)(NPC.damage * 0.35f), 0f);
						else Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-6, 12), Main.rand.NextFloat(-6, -9)), ModContent.ProjectileType<Projectiles.Bosses.ADD.DiskiteShrapnelHostile>(), (int)(NPC.damage * (0.45f - (0.1f*NPC.life/NPC.lifeMax))), 0f);
                    }
						
                }
				else if (attack == 5) {
					attackTimer++;
					if (attackTimer % (45 + (int)(30*NPC.life/NPC.lifeMax)) == 0) {
						SoundEngine.PlaySound(SoundID.Item93);
						Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, new Vector2(0, -8), ModContent.ProjectileType<Projectiles.Bosses.ADD.ADDZapChase>(), (int)(NPC.damage * (0.4f - (0.1f*NPC.life/NPC.lifeMax))), 0f);
					}
				}
				else if (attack == 6) {
					attackTimer++;
					if (attackTimer % 90 == 1) {
						SoundEngine.PlaySound(SoundID.Item92);
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<SupportDiskite>());
					}
				}
				else if (attack == 99) {
					attackTimer++;
					if (attackTimer < 30)
						NPC.velocity *= 0.95f;
					else if (attackTimer == 30) {
						atkVector = NPC.Center - target.Center;
						atkVector.Normalize();
						if (Main.expertMode) atkVector *= -34f;
						else atkVector *= -30f;
						NPC.velocity = atkVector;
					}
					else if (attackTimer < 150) {
						NPC.velocity *= 0.97f;
                    }
					else {
						attackDone = true;
						attackTimer = 0;
						atkVector = new Vector2(0, 0);
                    }
				}
			}
			if (Timer == 480) {
				Timer = 0;
				NPC.ai[1] = 0;
			}
			if (flee >= 1) {
                flee++;
                NPC.velocity.Y = 10f;
                if (flee >= 450)
                    NPC.active = false;
            }
			if (Vector2.Distance(NPC.Center, target.Center) > 1200) {
				Vector2 speed2 = NPC.Center - target.Center;
				speed2.Normalize();
				NPC.velocity = speed2 * -30f;
				catchUp = true;
			}
			if (Vector2.Distance(NPC.Center, target.Center) <= 1200 && catchUp)
				NPC.velocity /= 2;
			if (!(attack == 99 && attackDone == false) && Timer < 180)
				catchUp = false;
			if ((attack == 4 && Timer > 180 && attackTimer % 70 <= 30))
				catchUp = false;
        }
        public override void PostAI() {
            NPC.dontTakeDamage = true;
			if (NPC.CountNPCS(ModContent.NPCType<ADD_SideTop>()) > 0 || NPC.CountNPCS(ModContent.NPCType<ADD_SideBottom>()) > 0) { 
				NPC.dontTakeDamage = true;
				phase = false;
			}
			else {
				NPC.dontTakeDamage = false;
				phase = true;
            }
			if (!target.ZoneDesert && !target.ZoneUndergroundDesert) {
				NPC.dontTakeDamage = true;
			}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("An ancient drone-like machine made from technology that is obviously not from this planet.")
			});
		}
		public override void BossLoot(ref string name, ref int potionType) {
			ZylonWorldCheckSystem.downedADD = true;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			if (Main.masterMode) {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Relics.ADDRelic>(), 1));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Pets.DiskiteDrive>(), 4));
            }
			if (Main.expertMode) npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Bags.DiskiteBag>(), 1));
			else {
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.DiskiteCrumbles>(), 1, 10, 20));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Materials.RustedTech>(), 1, 25, 30));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.PolandballMask>(), 10));
				npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.ADDMask>(), 7)).OnFailedRoll(npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Vanity.PolandballMask>(), 10)));
            }
			npcLoot.Add(new CommonDrop(ModContent.ItemType<Items.Placeables.Trophies.ADDTrophy>(), 10));
		}
    }
}