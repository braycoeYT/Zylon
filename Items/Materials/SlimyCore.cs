using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SlimyCore : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Slimy Core");
			// Tooltip.SetDefault("'Part of a slime nucleus'");
		}
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 1);
			Item.rare = ItemRarityID.White;
		}
	}
}