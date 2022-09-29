using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Materials
{
	public class ElementalGoop : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Looks extra tasty!'");
		}
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 30;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.Lime;
		}
	}
}