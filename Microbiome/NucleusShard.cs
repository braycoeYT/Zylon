using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome
{
	public class NucleusShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nucleus Shard");
			Tooltip.SetDefault("Eww, it's managing cells on my hands...");
		}
		public override void SetDefaults() 
		{
			item.width = 38;
			item.height = 38;
			item.maxStack = 999;
			item.value = 2500;
			item.rare = ItemRarityID.White;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RottenChunk);
			recipe.AddIngredient(ItemID.Vertebrae);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}