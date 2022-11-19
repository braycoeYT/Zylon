using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Ocean
{
	public class LittoralGigaslime : ModNPC
	{
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 2;

			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
        }
        public override void SetDefaults() {
            NPC.width = 280;
			NPC.height = 180;
			NPC.damage = 60;
			NPC.defense = 20;
			NPC.lifeMax = 30000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 0;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			AnimationType = 1;
			NPC.alpha = 50;
			NPC.lavaImmune = true;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<Items.Banners.LittoralGigaslimeBanner>();
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 41000;
			NPC.damage = 97;
			NPC.defense = 45;
        }
        public override void HitEffect(int hitDirection, double damage) {
            if (NPC.life < NPC.lifeMax / 2) {
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + 50, (int)NPC.Center.Y, ModContent.NPCType<LittoralGigaslime2>(), 0);
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 50, (int)NPC.Center.Y, ModContent.NPCType<LittoralGigaslime2>(), 0);
				if (Main.expertMode) NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<LittoralGigaslime2>());
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<LittoralGigaslimeCore>());
				NPC.active = false;
            }
        }
        int xBoost;
		int yBoost;
		int Timer;
		float slimeAI0;
        public override void AI() {
			Timer++;

			//if (Timer % (60 + (90*(NPC.life/NPC.lifeMax))) == 0)
			//	Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, Vector2.Normalize(NPC.Center - (Main.player[NPC.target].Center - new Vector2(0, 100))) * -6f, ModContent.ProjectileType<Projectiles.Gigaslime.AcornTreePlant>(), (int)(NPC.damage * 0.3f), 0f, Main.myPlayer);
			
			if (Timer % 15 == 0 && ((NPC.life < NPC.lifeMax * 0.875f) || Main.expertMode)) { // + (90*(NPC.life/NPC.lifeMax))) == 0 && (Main.expertMode || NPC.life > NPC.lifeMax / 2))
				Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(Main.rand.Next(-5, 6) + (Main.rand.Next(-3, 4) * NPC.life/NPC.lifeMax), -8 - Main.rand.Next(0, 5)), ModContent.ProjectileType<Projectiles.Gigaslime.WaterStreamHostile>(), (int)(NPC.damage * 0.2f), 0f, Main.myPlayer);
				SoundEngine.PlaySound(SoundID.Item21, NPC.position);
			}

			if (Main.player[NPC.target].statLife < 1)
			{
				NPC.TargetClosest(true);
			}

			if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 500) xBoost = 6;
			else xBoost = 0;

			if (NPC.Center.Y - Main.player[NPC.target].Center.Y > 250) yBoost = 8;
			else yBoost = 0;

			//if (NPC.Center.Y - Main.player[NPC.target].Center.Y > 300) NPC.velocity.Y -= 1;

			if (NPC.velocity.Y < 0 || (NPC.Center.Y < Main.player[NPC.target].Center.Y - 80)) NPC.noTileCollide = true; //20
			else NPC.noTileCollide = false;

            if (NPC.type == NPCID.BlueSlime && (NPC.ai[1] == 1f || NPC.ai[1] == 2f || NPC.ai[1] == 3f))
			{
				NPC.ai[1] = -1f;
			}
			if (NPC.type == NPCID.BlueSlime && NPC.ai[1] == 0f && Main.netMode != NetmodeID.MultiplayerClient && NPC.value > 0f)
			{
				NPC.ai[1] = -1f;
				if (Main.rand.NextBool(20))
				{
					int num = Main.rand.Next(4);
					if (num == 0)
					{
						num = Main.rand.Next(7);
						if (num == 0)
						{
							num = 290;
						}
						else if (num == 1)
						{
							num = 292;
						}
						else if (num == 2)
						{
							num = 296;
						}
						else if (num == 3)
						{
							num = 2322;
						}
						else if (Main.netMode != NetmodeID.SinglePlayer && Main.rand.NextBool(2))
						{
							num = 2997;
						}
						else
						{
							num = 2350;
						}
					}
					else if (num == 1)
					{
						num = Main.rand.Next(4);
						if (num == 0)
						{
							num = 8;
						}
						else if (num == 1)
						{
							num = 166;
						}
						else if (num == 2)
						{
							num = 965;
						}
						else
						{
							num = 58;
						}
					}
					else if (num == 2)
					{
						if (Main.rand.NextBool(2))
						{
							num = Main.rand.Next(11, 15);
						}
						else
						{
							num = Main.rand.Next(699, 703);
						}
					}
					else
					{
						num = Main.rand.Next(3);
						if (num == 0)
						{
							num = 71;
						}
						else if (num == 1)
						{
							num = 72;
						}
						else
						{
							num = 73;
						}
					}
					NPC.ai[1] = (float)num;
					NPC.netUpdate = true;
				}
			}
			bool flag = true; //npc aggro
			slimeAI0 += 1f;
			/*if (NPC.type == 244)
			{
				flag = true;
				slimeAI0 += 2f;
			}*/
			/*if (NPC.type == 204)
			{
				flag = true;
				if (NPC.localAI[0] > 0f)
				{
					NPC.localAI[0] -= 1f;
				}
				if (!NPC.wet && !Main.player[NPC.target].npcTypeNoAggro[NPC.type])
				{
					Vector2 vector5 = new Vector2(NPC.position.X + (float)NPC.width * 0.5f, NPC.position.Y + (float)NPC.height * 0.5f);
					float num14 = Main.player[NPC.target].position.X + (float)Main.player[NPC.target].width * 0.5f - vector5.X;
					float num15 = Main.player[NPC.target].position.Y - vector5.Y;
					float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
					if (Main.expertMode && num16 < 200f && Collision.CanHit(new Vector2(NPC.position.X, NPC.position.Y - 20f), NPC.width, NPC.height + 20, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && NPC.velocity.Y == 0f)
					{
						slimeAI0 = -40f;
						if (NPC.velocity.Y == 0f)
						{
							NPC.velocity.X = NPC.velocity.X * 0.9f;
						}
						if (Main.netMode != 1 && NPC.localAI[0] == 0f)
						{
							for (int k = 0; k < 5; k++)
							{
								Vector2 vector6 = new Vector2((float)(k - 2), -2f);
								vector6.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.02f;
								vector6.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.02f;
								vector6.Normalize();
								vector6 *= 3f + (float)Main.rand.Next(-50, 51) * 0.01f;
								Projectile.NewProjectile(vector5.X, vector5.Y, vector6.X, vector6.Y, 176, 13, 0f, Main.myPlayer, 0f, 0f);
								NPC.localAI[0] = 80f;
							}
						}
					}
					if (num16 < 400f && Collision.CanHit(new Vector2(NPC.position.X, NPC.position.Y - 20f), NPC.width, NPC.height + 20, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && NPC.velocity.Y == 0f)
					{
						slimeAI0 = -80f;
						if (NPC.velocity.Y == 0f)
						{
							NPC.velocity.X = NPC.velocity.X * 0.9f;
						}
						if (Main.netMode != 1 && NPC.localAI[0] == 0f)
						{
							num15 = Main.player[NPC.target].position.Y - vector5.Y - (float)Main.rand.Next(-30, 20);
							num15 -= num16 * 0.05f;
							num14 = Main.player[NPC.target].position.X - vector5.X - (float)Main.rand.Next(-20, 20);
							num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
							num16 = 7f / num16;
							num14 *= num16;
							num15 *= num16;
							NPC.localAI[0] = 65f;
							Projectile.NewProjectile(vector5.X, vector5.Y, num14, num15, 176, 13, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
			}*/
			if (NPC.ai[2] > 1f)
			{
				NPC.ai[2] -= 1f;
			}
			/*if (NPC.wet)
			{
				if (NPC.collideY)
				{
					NPC.velocity.Y = -2f;
				}
				if (NPC.velocity.Y < 0f && NPC.ai[3] == NPC.position.X)
				{
					NPC.direction *= -1;
					NPC.ai[2] = 200f;
				}
				if (NPC.velocity.Y > 0f)
				{
					NPC.ai[3] = NPC.position.X;
				}
				if (NPC.type == 59)
				{
					if (NPC.velocity.Y > 2f)
					{
						NPC.velocity.Y = NPC.velocity.Y * 0.9f;
					}
					else if (NPC.directionY < 0)
					{
						NPC.velocity.Y = NPC.velocity.Y - 0.8f;
					}
					NPC.velocity.Y = NPC.velocity.Y - 0.5f;
					if (NPC.velocity.Y < -10f)
					{
						NPC.velocity.Y = -10f;
					}
				}
				else
				{
					if (NPC.velocity.Y > 2f)
					{
						NPC.velocity.Y = NPC.velocity.Y * 0.9f;
					}
					NPC.velocity.Y = NPC.velocity.Y - 0.5f;
					if (NPC.velocity.Y < -4f)
					{
						NPC.velocity.Y = -4f;
					}
				}
				if (NPC.ai[2] == 1f & flag)
				{
					NPC.TargetClosest(true);
				}
			}*/
			NPC.aiAction = 0;
			if (NPC.ai[2] == 0f)
			{
				slimeAI0 = -100f;
				NPC.ai[2] = 1f;
				NPC.TargetClosest(true);
			}
			if (NPC.velocity.Y == 0f || (NPC.Center.Y - Main.player[NPC.target].Center.Y > 300))
			{
				if (NPC.collideY && NPC.oldVelocity.Y != 0f && Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
				{
					NPC.position.X = NPC.position.X - (NPC.velocity.X + (float)NPC.direction);
				}
				if (NPC.ai[3] == NPC.position.X)
				{
					NPC.direction *= -1;
					NPC.ai[2] = 200f;
				}
				NPC.ai[3] = 0f;
				NPC.velocity.X = NPC.velocity.X * 0.8f;
				if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
				{
					NPC.velocity.X = 0f;
				}
				if (flag)
				{
					slimeAI0 += 1f;
				}
				slimeAI0 += 2f;
				int num19 = 0;
				if (slimeAI0 >= 0f)
				{
					num19 = 1;
				}
				if (slimeAI0 >= -1000f && slimeAI0 <= -500f)
				{
					num19 = 2;
				}
				if (slimeAI0 >= -2000f && slimeAI0 <= -1500f)
				{
					num19 = 3;
				}
				if (num19 > 0)
				{
					NPC.netUpdate = true;
					if (flag && NPC.ai[2] == 1f)
					{
						NPC.TargetClosest(true);
					}
					if (num19 == 3)
					{
						NPC.velocity.Y = -13f - yBoost; //-11 og giga
						NPC.velocity.X = NPC.velocity.X + (float)((7+xBoost) * NPC.direction); //3
						slimeAI0 = -200f;
						NPC.ai[3] = NPC.position.X;
					}
					else
					{
						NPC.velocity.Y = -10f - yBoost; //-8 og giga
						NPC.velocity.X = NPC.velocity.X + (float)((5+xBoost) * NPC.direction); //2
						slimeAI0 = -120f;
						if (num19 == 1)
						{
							slimeAI0 -= 1000f;
						}
						else
						{
							slimeAI0 -= 2000f;
						}
					}
				}
				else if (slimeAI0 >= -30f)
				{
					NPC.aiAction = 1;
					return;
				}
			}
			else if (NPC.target < 255 && ((NPC.direction == 1 && NPC.velocity.X < 3f) || (NPC.direction == -1 && NPC.velocity.X > -3f)))
			{
				if (NPC.collideX && Math.Abs(NPC.velocity.X) == 0.2f)
				{
					NPC.position.X = NPC.position.X - 1.4f * (float)NPC.direction;
				}
				if (NPC.collideY && NPC.oldVelocity.Y != 0f && Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
				{
					NPC.position.X = NPC.position.X - (NPC.velocity.X + (float)NPC.direction);
				}
				if ((NPC.direction == -1 && (double)NPC.velocity.X < 0.01) || (NPC.direction == 1 && (double)NPC.velocity.X > -0.01))
				{
					NPC.velocity.X = NPC.velocity.X + 0.2f * (float)NPC.direction;
					return;
				}
				NPC.velocity.X = NPC.velocity.X * 0.93f;
			}
		}
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("A massive slime that is almost entirely water. Due to this, it splits much more than the average slime.")
			});
			bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPC.type], quickUnlock: true);
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!NPC.downedPlantBoss) return 0f;
            return (SpawnCondition.OceanMonster.Chance) * 0.002f;
        }
    }
}