using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Ocean
{
	public class LittoralGigaslimeCore : ModNPC
	{
        public override void SetDefaults() {
            NPC.width = 64;
			NPC.height = 64;
			NPC.damage = 80;
			NPC.defense = 0;
			NPC.lifeMax = 1000;
			NPC.HitSound = SoundID.NPCHit13;
			NPC.DeathSound = SoundID.NPCDeath19;
			NPC.value = 30000;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.alpha = 50;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			Banner = Item.NPCtoBanner(ModContent.NPCType<LittoralGigaslime>());
			BannerItem = Item.BannerToItem(Banner);
			Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/SlimyDemise2");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 1500;
			NPC.damage = 110;
			NPC.value = 60000;
			NPC.defense = 0;
        }
        public override void AI() {
			NPC.dontTakeDamage = false;
			for (int i = 0; i < Main.maxNPCs; i++) {
				if ((Main.npc[i].type == ModContent.NPCType<LittoralGigaslime2>() || Main.npc[i].type == ModContent.NPCType<LittoralGigaslime3>()) && Main.npc[i].life > 0 && Main.npc[i].active == true)
					NPC.dontTakeDamage = true;
            }
            NPC.noTileCollide = true;

			//Vector2 temp = Main.player[NPC.target].Center - NPC.Center;
			//temp.Normalize();
			//NPC.velocity -= temp * 3;
																	if (NPC.ai[0] == 0f)
																	{
																		NPC.TargetClosest(true);
																		if (Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
																		{
																			NPC.ai[0] = 1f;
																		}
																		else
																		{
																			Vector2 value29 = (Main.player[NPC.target].Center - NPC.Center); //*2; //CHANGED
																			value29.Y -= (float)(Main.player[NPC.target].height / 4);
																			float num1310 = value29.Length();
																			if (num1310 > 800f)
																			{
																				NPC.ai[0] = 2f;
																			}
																			else
																			{
																				Vector2 center26 = NPC.Center;
																				center26.X = Main.player[NPC.target].Center.X;
																				Vector2 vector230 = center26 - NPC.Center;
																				if (vector230.Length() > 8f && Collision.CanHit(NPC.Center, 1, 1, center26, 1, 1))
																				{
																					NPC.ai[0] = 3f;
																					NPC.ai[1] = center26.X;
																					NPC.ai[2] = center26.Y;
																					Vector2 center27 = NPC.Center;
																					center27.Y = Main.player[NPC.target].Center.Y;
																					if (vector230.Length() > 8f && Collision.CanHit(NPC.Center, 1, 1, center27, 1, 1) && Collision.CanHit(center27, 1, 1, Main.player[NPC.target].position, 1, 1))
																					{
																						NPC.ai[0] = 3f;
																						NPC.ai[1] = center27.X;
																						NPC.ai[2] = center27.Y;
																					}
																				}
																				else
																				{
																					center26 = NPC.Center;
																					center26.Y = Main.player[NPC.target].Center.Y;
																					if ((center26 - NPC.Center).Length() > 8f && Collision.CanHit(NPC.Center, 1, 1, center26, 1, 1))
																					{
																						NPC.ai[0] = 3f;
																						NPC.ai[1] = center26.X;
																						NPC.ai[2] = center26.Y;
																					}
																				}
																				if (NPC.ai[0] == 0f)
																				{
																					NPC.localAI[0] = 0f;
																					value29.Normalize();
																					//value29 *= 0.5f;
																					NPC.velocity += value29;
																					NPC.ai[0] = 4f;
																					NPC.ai[1] = 0f;
																				}
																			}
																		}
																	}
																	else if (NPC.ai[0] == 1f)
																	{
																		NPC.rotation += (float)NPC.direction * 0.3f;
																		Vector2 value30 = (Main.player[NPC.target].Center - NPC.Center); //*-2; //CHANGED
																		float num1311 = value30.Length();
																		float num1312 = 5.5f;
																		num1312 += num1311 / 100f;
																		int num1313 = 50;
																		value30.Normalize();
																		value30 *= num1312;
																		NPC.velocity = (NPC.velocity * (float)(num1313 - 1) + value30) / (float)num1313;
																		if (!Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
																		{
																			NPC.ai[0] = 0f;
																			NPC.ai[1] = 0f;
																		}
																	}
																	else if (NPC.ai[0] == 2f)
																	{
																		NPC.rotation = NPC.velocity.X * 0.1f;
																		NPC.noTileCollide = true;
																		Vector2 value31 = Main.player[NPC.target].Center - NPC.Center;
																		float num1315 = value31.Length();
																		float scaleFactor11 = 3f;
																		int num1316 = 3;
																		value31.Normalize();
																		value31 *= scaleFactor11;
																		NPC.velocity = (NPC.velocity * (float)(num1316 - 1) + value31) / (float)num1316;
																		if (num1315 < 600f && !Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
																		{
																			NPC.ai[0] = 0f;
																		}
																	}
																	else if (NPC.ai[0] == 3f)
																	{
																		NPC.rotation = NPC.velocity.X * 0.1f;
																		Vector2 value32 = new Vector2(NPC.ai[1], NPC.ai[2]);
																		Vector2 value33 = value32 - NPC.Center;
																		float num1317 = value33.Length();
																		float num1318 = 2f;
																		float num1319 = 3f;
																		value33.Normalize();
																		value33 *= num1318;
																		NPC.velocity = (NPC.velocity * (num1319 - 1f) + value33) / num1319;
																		if (NPC.collideX || NPC.collideY)
																		{
																			NPC.ai[0] = 4f;
																			NPC.ai[1] = 0f;
																		}
																		if (num1317 < num1318 || num1317 > 800f || Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
																		{
																			NPC.ai[0] = 0f;
																		}
																	}
																	else if (NPC.ai[0] == 4f)
																	{
																		NPC.rotation = NPC.velocity.X * 0.1f;
																		if (NPC.collideX)
																		{
																			NPC.velocity.X = NPC.velocity.X * -0.8f;
																		}
																		if (NPC.collideY)
																		{
																			NPC.velocity.Y = NPC.velocity.Y * -0.8f;
																		}
																		Vector2 value34;
																		if (NPC.velocity.X == 0f && NPC.velocity.Y == 0f)
																		{
																			value34 = Main.player[NPC.target].Center - NPC.Center;
																			value34.Y -= (float)(Main.player[NPC.target].height / 4);
																			value34.Normalize();
																			NPC.velocity = value34 * 0.1f;
																		}
																		float scaleFactor12 = 2f;
																		float num1320 = 20f;
																		value34 = NPC.velocity;
																		value34.Normalize();
																		value34 *= scaleFactor12;
																		NPC.velocity = (NPC.velocity * (num1320 - 1f) + value34) / num1320;
																		NPC.ai[1] += 1f;
																		if (NPC.ai[1] > 180f)
																		{
																			NPC.ai[0] = 0f;
																			NPC.ai[1] = 0f;
																		}
																		if (Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
																		{
																			NPC.ai[0] = 0f;
																		}
																		NPC.localAI[0] += 1f;
																		if (NPC.localAI[0] >= 5f && !Collision.SolidCollision(NPC.position - new Vector2(10f, 10f), NPC.width + 20, NPC.height + 20))
																		{
																			NPC.localAI[0] = 0f;
																			Vector2 center28 = NPC.Center;
																			center28.X = Main.player[NPC.target].Center.X;
																			if (Collision.CanHit(NPC.Center, 1, 1, center28, 1, 1) && Collision.CanHit(NPC.Center, 1, 1, center28, 1, 1) && Collision.CanHit(Main.player[NPC.target].Center, 1, 1, center28, 1, 1))
																			{
																				NPC.ai[0] = 3f;
																				NPC.ai[1] = center28.X;
																				NPC.ai[2] = center28.Y;
																			}
																			else
																			{
																				center28 = NPC.Center;
																				center28.Y = Main.player[NPC.target].Center.Y;
																				if (Collision.CanHit(NPC.Center, 1, 1, center28, 1, 1) && Collision.CanHit(Main.player[NPC.target].Center, 1, 1, center28, 1, 1))
																				{
																					NPC.ai[0] = 3f;
																					NPC.ai[1] = center28.X;
																					NPC.ai[2] = center28.Y;
																				}
																			}
																		}
																	}
																	else if (NPC.ai[0] == 5f)
																	{
																		Player player7 = Main.player[NPC.target];
																		if (!player7.active || player7.dead)
																		{
																			NPC.ai[0] = 0f;
																			NPC.ai[1] = 0f;
																			NPC.netUpdate = true;
																		}
																		else
																		{
																			NPC.Center = ((player7.gravDir == 1f) ? player7.Top : player7.Bottom) + new Vector2((float)(player7.direction * 4), 0f);
																			NPC.gfxOffY = player7.gfxOffY;
																			NPC.velocity = Vector2.Zero;
																			player7.AddBuff(163, 59, true);
																		}
																	}
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("The core of a slime that is almost entirely water. The slime needs a reinforced and independent core because of its rapid splitting rate.")
			});
			bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPC.type], quickUnlock: true);
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(new CommonDrop(ItemID.Gel, 1, 40, 50, 1));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Materials.ElementalGoop>(), 1, 5, 10), new CommonDrop(ModContent.ItemType<Items.Materials.ElementalGoop>(), 1, 7, 15)));
			npcLoot.Add(new DropBasedOnExpertMode(new CommonDrop(ModContent.ItemType<Items.Wands.OceanWaterer>(), 2), new CommonDrop(ModContent.ItemType<Items.Wands.OceanWaterer>(), 1)));
			npcLoot.Add(new CommonDrop(ItemID.SandBlock, 1, 20, 30));
			npcLoot.Add(new CommonDrop(ItemID.Coral, 1, 3, 5));
			npcLoot.Add(new CommonDrop(ItemID.Seashell, 1, 3, 5));
			npcLoot.Add(new CommonDrop(ItemID.Starfish, 1, 3, 5));
			npcLoot.Add(new CommonDrop(ItemID.BlackInk, 3));
		}
    }
}