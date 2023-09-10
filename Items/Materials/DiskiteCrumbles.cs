using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class DiskiteCrumbles : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'It seems to be made of something familiar, but you can't tell what...'");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.White;
		}
	}
}