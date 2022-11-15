using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials.Fish
{
	public class PaintedGlassTetra : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Don't drop it! Dropping regular glass was already enough of a mess...'\nDue to low visibility, only catchable under the usage of a hunter potion");
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 34;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 17, 50);
			Item.rare = ItemRarityID.Blue;
		}
	}
}