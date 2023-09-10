using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class WindEssence : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Resembles cotton candy, but tastes like cold air.'");
        }
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 28;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.White;
		}
	}
}