using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class ZylonGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
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
			}
			if (npc.type == NPCID.IceElemental)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
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
			if (npc.type == NPCID.IceQueen)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>(), 12 + Main.rand.Next(2));
			}
			if (npc.type == NPCID.KingSlime)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.PHVBoss.KingSlicer>());
			    if (Main.expertMode)
				{
					if (Main.rand.NextFloat() < .05f)
						Item.NewItem(npc.getRect(), ItemType<Items.Zylomax.NuclearGenerator>());
				}
				else
				{
					if (Main.rand.NextFloat() < .025f)
						Item.NewItem(npc.getRect(), ItemType<Items.Zylomax.NuclearGenerator>());
				}
			}
			if (npc.type == NPCID.Creeper)
			{
				if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MeatEye>());
			}
			if (npc.type == NPCID.Retinazer)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.EyeOfPrejudice>());
			}
			if (npc.type == 13)
			{
				if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.VileEye>());
			}
			if (npc.type == 14)
			{
				if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.VileEye>());
			}
			if (npc.type == 15)
			{
				if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.VileEye>());
			}
		}
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Cyborg)
			{
				if (NPC.downedMoonlord)
				{
				shop.item[nextSlot].SetDefaults(ItemType<Items.DreamString>());
				shop.item[nextSlot].shopCustomPrice = 3300;
				nextSlot++;
				}
			}
		}
	}
}