using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class ZylonGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool xenicAcid;
		public override void ResetEffects(NPC npc) {
			xenicAcid = false;
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if (type == NPCID.ArmsDealer) {
				if (NPC.downedBoss2) {
					if (Main.hardMode || !Main.dayTime) {
						shop.item[nextSlot].SetDefaults(ItemType<Items.OtherArrows.UnethicalArrow>());
						nextSlot++;
					}
				}
			}
			if (type == NPCID.Dryad) {
				shop.item[nextSlot].SetDefaults(ItemID.Seed);
				shop.item[nextSlot].shopCustomPrice = 3;
				nextSlot++;
			}
			if (type == NPCID.WitchDoctor) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("Vineshot"));
				shop.item[nextSlot].shopCustomPrice = 8;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.PoisonDart);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
			}
		}
		public override void SetDefaults(NPC npc) {
			if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == NPCID.GolemHead || npc.type == NPCID.GolemHeadFree || npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore || npc.type == NPCID.MoonLordFreeEye || npc.type == NPCID.MoonLordHand || npc.type == NPCID.MoonLordHead) {
				npc.buffImmune[mod.BuffType("Sick")] = true;
			}
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (xenicAcid) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 50;
				if (damage < 25) {
					damage = 25;
				}
			}
		}
		public override void DrawEffects(NPC npc, ref Color drawColor) {
			if (xenicAcid) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 107, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}
		public override void NPCLoot(NPC npc) {
			if (ZylonWorld.microbiomeTiles > 140 && Main.hardMode) {
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight) {
					if (Main.expertMode) {
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .33f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
					else {
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .2f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ZylonPlayer>().mineralExpert) {
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticSoul"));
			}
			if (NPC.downedPlantBoss && (npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime || npc.type == NPCID.SpikedJungleSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.LavaSlime || npc.type == NPCID.DungeonSlime || npc.type == NPCID.UmbrellaSlime)) {
				if (Main.rand.NextFloat() < .1f)
					Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"));
			}
			if (NPC.downedPlantBoss && (npc.type == NPCID.RainbowSlime || npc.type == NPCID.Pinky)) {
				Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"), Main.rand.Next(1, 4));
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.hardMode && Main.rand.NextFloat() < .1f) {
				Item.NewItem(npc.getRect(), mod.ItemType("Electrolight"));
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneBeach && NPC.downedBoss3 && !NPC.downedMechBossAny && Main.rand.NextFloat() < .01f) {
				Item.NewItem(npc.getRect(), mod.ItemType("AquaticJavelance"));
			}
			if (npc.type == NPCID.Derpling || npc.type == NPCID.GiantTortoise || npc.type == NPCID.GiantFlyingFox || npc.type == NPCID.AngryTrapper || npc.type == NPCID.Arapaima) {
				if (Main.rand.NextFloat() < .01f)
					Item.NewItem(npc.getRect(), mod.ItemType("VenomousPill"));
			}
			if (!ZylonWorld.downedDirtball) {
				if (Main.rand.Next(100) == 1)
				Item.NewItem(npc.getRect(), ItemType<Items.Dirtball.CreepyMud>());
			}
			if (npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.SnowFlinx || npc.type == NPCID.IceBat) {
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.JungleBat || npc.type == NPCID.CaveBat || npc.type == NPCID.IceBat || npc.type == NPCID.CaveBat) {
			    if (Main.rand.Next(50) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.EyeofCthulhu) {
				if (Main.rand.NextFloat() < .25f)
				Item.NewItem(npc.getRect(), mod.ItemType("OpticBlowpipe"));
				Item.NewItem(npc.getRect(), ItemType<Items.Eye.GlazedLens>(), Main.rand.Next(2, 6));
				Item.NewItem(npc.getRect(), ItemType<Items.Microbiome.TwistedMembraneOre>(), Main.rand.Next(30, 88));
			}
			if (npc.type == NPCID.KingSlime) {
				Item.NewItem(npc.getRect(), ItemType<Items.Slime.SlimyCore>(), Main.rand.Next(8, 12));
			}
			if (npc.type == NPCID.Retinazer || npc.type == NPCID.SkeletronPrime) {
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.EyeThemed.ShardOfPrejudice>());
			}
			if (npc.type == NPCID.Plantera) {
				Item.NewItem(npc.getRect(), ItemType<Items.PlanteraTooth>(), Main.rand.Next(1, 5));
				if (Main.rand.Next(3) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.FruitOfLife>());
			}
			if (npc.type == NPCID.Mothron) {
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.OtherJavelances.AncientMedievalJavelance>(), Main.rand.Next(1, 6));
			}
			if (npc.type == NPCID.Golem) {
				if (Main.rand.Next(3) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.SunProtection>());
			}
			if (npc.type == NPCID.WallofFlesh) {
				int rand = Main.rand.Next(0, 5);
				if (rand == 0)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshCutter"));
				if (rand == 1)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshyCube"));
				if (rand == 2)
					Item.NewItem(npc.getRect(), mod.ItemType("Fleshbow"));
				if (rand == 3)
					Item.NewItem(npc.getRect(), mod.ItemType("Fleshclump"));
				if (rand == 4)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshBlowpipe"));
			}
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) {
				if (Main.rand.NextFloat() < .12f)
					Item.NewItem(npc.getRect(), mod.ItemType("BloodySpiderLeg"));
			}
			if (npc.type == NPCID.MartianSaucerCore) {
				if (Main.rand.NextFloat() < .4f)
					Item.NewItem(npc.getRect(), mod.ItemType("ElectrifyingScent"));
			}
			//blowpipes:
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("FrostBlowpipe")))
				if (npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime || npc.type == mod.NPCType("IcyDiscus")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("IcySeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("MagentiteBlowpipe")))
				if (npc.type == mod.NPCType("MagentiteSlime") || npc.type == mod.NPCType("MagentiteDiscus") || npc.type == mod.NPCType("MagentiteStinger")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("MagentiteSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("WoodenBlowpipe")))
				if (npc.type == -3 || npc.type == 1) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("PinkyBlowpipe")))
				if (npc.type == -4) {
					Item.NewItem(npc.getRect(), mod.ItemType("PinkySeedshot"), Main.rand.Next(30, 51));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("SlimyBlowpipe")))
				if (npc.type == 1 || npc.type == -7 || npc.type == 535) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("SlimySeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("DirtyBlowpipe")))
				if (npc.type == mod.NPCType("DirtySlime") || npc.type == mod.NPCType("DirtyDiscus")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("EaterOfSeeds")))
				if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == mod.NPCType("CorruptDiscus")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("CorruptSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("BloodyBlowpipe")))
				if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == mod.NPCType("VeinTunnelerHead") || npc.type == NPCID.FaceMonster || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("CrimtaneSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("OpticBlowpipe")))
				if (npc.type == NPCID.CataractEye || npc.type == NPCID.CataractEye2 || npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship || npc.type == NPCID.DialatedEye || npc.type == NPCID.DialatedEye2 || npc.type == NPCID.GreenEye || npc.type == NPCID.GreenEye2 || npc.type == NPCID.PurpleEye || npc.type == NPCID.PurpleEye2 || npc.type == NPCID.SleepyEye || npc.type == NPCID.SleepyEye2) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("FleshBlowtube")))
				if (npc.type == NPCID.Demon || npc.type == NPCID.FireImp || npc.type == NPCID.LavaSlime) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("HitmansBlowscope")))
				if (npc.type == mod.NPCType("MechanicalSlime")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("MeatCannon")))
				if (npc.type == mod.NPCType("Meatball1") || npc.type == mod.NPCType("Meatball2") || npc.type == mod.NPCType("Meatball3") || npc.type == mod.NPCType("Meatball4") || npc.type == mod.NPCType("Meatball5")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
		}
		public override void SetupTravelShop(int[] shop, ref int nextSlot) {
			if (Main.rand.Next(0, 5) == 0) {
                shop[nextSlot] = mod.ItemType("IronfistMedal");
                nextSlot++;
            }
		}
	}
}