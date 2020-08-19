using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Furniture.Platforms.PHOres
{
	public class TungstenPlatform : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 30;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 2250;
			item.createTile = TileType<Tiles.Furniture.Platforms.PHOres.TungstenPlatform>();
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 1);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}
	}
}