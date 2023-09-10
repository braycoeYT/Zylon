using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class LivingBranch : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Enchanted with an ancient forest magic'");
		}
		public override void SetDefaults() {
			Item.width = 44;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 16);
			Item.rare = ItemRarityID.White;
		}
	}
}