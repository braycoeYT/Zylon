using Zylon.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class CellBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 99;
			item.consumable = true;
			item.width = 40;
			item.height = 36;
			item.rare = 12;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(mod.ItemType("TwistedMembraneOre"), Main.rand.Next(55, 106));
			player.QuickSpawnItem(mod.ItemType("Cytoplasm"), Main.rand.Next(37, 58));
			player.QuickSpawnItem(mod.ItemType("HyperchargedNucleolus"));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.ColossalNucleus>();
	}
}