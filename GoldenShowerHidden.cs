using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}