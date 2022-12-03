using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class Oozeberry : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Unfit and unsafe for consumption due to its strong poison'");
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1, 50);
			Item.rare = ItemRarityID.Orange;
		}
	}
}