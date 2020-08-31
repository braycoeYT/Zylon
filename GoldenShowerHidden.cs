using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class GoldenShowerHidden : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Shower (Hidden)");
			Tooltip.SetDefault("I gotta go\nUse the golden shower without the book");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.GoldenShower);
			item.noUseGraphic = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldenShower);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}