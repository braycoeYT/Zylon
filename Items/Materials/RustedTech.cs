using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class RustedTech : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Ancient tech worn by the figurative and literal sands of time...'");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1);
			Item.rare = ItemRarityID.Blue;
		}
	}
}