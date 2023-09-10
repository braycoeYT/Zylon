using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Food
{
	public class CocoaBeans : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Used to make Brown Dye");
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 40);
			Item.rare = ItemRarityID.Blue;
		}
	}
}