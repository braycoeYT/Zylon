using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class BasicBowMold : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Used to craft basic special bows");
		}
		public override void SetDefaults() {
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}