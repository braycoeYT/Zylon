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
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer)
			{
				if (NPC.downedBoss2)
				{
					if (Main.hardMode || !Main.dayTime)
					{
						shop.item[nextSlot].SetDefaults(ItemType<Items.OtherArrows.UnethicalArrow>());
						nextSlot++;
					}
				}
			}
		}
		public override void SetDefaults(NPC npc)
		{
			if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.Plantera || npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == NPCID.GolemHead || npc.type == NPCID.GolemHeadFree || npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore || npc.type == NPCID.MoonLordFreeEye || npc.type == NPCID.MoonLordHand || npc.type == NPCID.MoonLordHead)
			{
				npc.buffImmune[mod.BuffType("Sick")] = true;
			}
		}
		public override void NPCLoot(NPC npc)
		{
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ZylonPlayer>().ZoneMicrobiome && Main.hardMode)
			{
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight)
				{
					if (Main.expertMode)
					{
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .33f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
					else
					{
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .2f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.hardMode && Main.rand.NextFloat() < .25f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("Electrolight"));
			}
			if (npc.type == NPCID.Derpling || npc.type == NPCID.GiantTortoise || npc.type == NPCID.GiantFlyingFox || npc.type == NPCID.AngryTrapper || npc.type == NPCID.Arapaima)
			{
				if (Main.rand.NextFloat() < .01f)
					Item.NewItem(npc.getRect(), mod.ItemType("VenomousPill"));
			}
			if (npc.type == NPCID.Corruptor)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.Dark.DarkStarMedal>());
			}
			if (npc.type == NPCID.CorruptSlime)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.Dark.DarkStarMedal>());
			}
			if (npc.type == NPCID.Slimer)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.Dark.DarkStarMedal>());
			}
			if (npc.type == NPCID.Herpling)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.Dark.DarkStarMedal>());
			}
			if (npc.type == NPCID.Crimslime)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.Dark.DarkStarMedal>());
			}
			if (!ZylonWorld.downedDirtball)
			{
				if (Main.rand.Next(100) == 1)
				Item.NewItem(npc.getRect(), ItemType<Items.BossSummon.CreepyMud>());
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				if (!ZylonWorld.hasConversationDrop)
				{
					Item.NewItem(npc.getRect(), ItemType<Items.OtherStory.MysteriousConversation>());
					ZylonWorld.hasConversationDrop = true;
				}
			}
			if (npc.type == NPCID.LunarTowerSolar)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerVortex)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerNebula)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(4, 6));
			}
			if (npc.type == NPCID.LunarTowerStardust)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(4, 6));
			}
			if (npc.type == NPCID.IceSlime)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.IceBat)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			    if (Main.rand.Next(50) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.SpikedIceSlime)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.SnowFlinx)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.Stalkeye>());
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.GlazedLens>(), Main.rand.Next(2, 6));
				Item.NewItem(npc.getRect(), ItemType<Items.Microbiome.TwistedMembraneOre>(), Main.rand.Next(30, 88));
				if (Main.rand.NextFloat() < .03f)
					Item.NewItem(npc.getRect(), mod.ItemType("InsomniaInsignia"));
			}
			if (npc.type == NPCID.KingSlime)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.Slime.SlimyCore>(), Main.rand.Next(8, 12));
			}
			if (npc.type == NPCID.Retinazer)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.EyeThemed.ShardOfPrejudice>());
			}
			if (npc.type == NPCID.Spazmatism)
			{
				/*if (ZylonWorld.voidDream == true)
				{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.VoidDream.GreenSpicyMechanicalCurry>());
			    }*/
			}
			if (npc.type == NPCID.JungleBat)
			{
			    if (Main.rand.Next(50) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.GiantBat)
			{
			    if (Main.rand.Next(50) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.CaveBat)
			{
				if (Main.rand.Next(50) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.Plantera)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.PlanteraTooth>(), Main.rand.Next(1, 5));
				if (Main.rand.Next(3) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.FruitOfLife>());
			}
			if (npc.type == NPCID.Mothron)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.OtherJavelances.AncientMedievalJavelance>(), Main.rand.Next(1, 6));
			}
			if (npc.type == NPCID.Drippler)
			{
				if (NPC.downedBoss3)
				{
					if (Main.rand.Next(8) == 0)
						Item.NewItem(npc.getRect(), ItemType<Items.Meatball.PlainNoodle>());
					Item.NewItem(npc.getRect(), ItemType<Items.Meatball.MeatShard>(), Main.rand.Next(1, 9));
				}
			}
			if (npc.type == NPCID.Golem)
			{
				if (Main.rand.Next(3) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Accessories.SunProtection>());
			}
			if (npc.type == NPCID.FlyingFish)
			{
				if (Main.rand.NextFloat() < .001f)
					Item.NewItem(npc.getRect(), mod.ItemType("RainbowRose"), Main.rand.Next(1, 4));
			}
			if (npc.type == NPCID.UmbrellaSlime)
			{
				if (Main.rand.NextFloat() < .001f)
					Item.NewItem(npc.getRect(), mod.ItemType("RainbowRose"), Main.rand.Next(1, 4));
			}
			if (npc.type == NPCID.ZombieRaincoat)
			{
				if (Main.rand.NextFloat() < .001f)
					Item.NewItem(npc.getRect(), mod.ItemType("RainbowRose"), Main.rand.Next(1, 4));
			}
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall)
			{
				if (Main.rand.NextFloat() < .12f)
					Item.NewItem(npc.getRect(), mod.ItemType("BloodySpiderLeg"));
			}
			if (npc.type == NPCID.MartianSaucerCore)
			{
				if (Main.rand.NextFloat() < .4f)
					Item.NewItem(npc.getRect(), mod.ItemType("ElectrifyingScent"));
			}
		}
	}
}