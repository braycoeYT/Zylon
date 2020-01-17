using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExampleMod.NPCs
{
	public class ExampleGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.LunarTowerSolar)
			{
				Item.NewItem(npc.getRect(), ItemType<Zylon.Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerVortex)
			{
				Item.NewItem(npc.getRect(), ItemType<Zylon.Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerNebula)
			{
				Item.NewItem(npc.getRect(), ItemType<Zylon.Items.DreamString>(), Main.rand.Next(4, 6));
			}
			if (npc.type == NPCID.LunarTowerStardust)
			{
				Item.NewItem(npc.getRect(), ItemType<Zylon.Items.DreamString>(), Main.rand.Next(4, 6));
			}
		}
	}
}