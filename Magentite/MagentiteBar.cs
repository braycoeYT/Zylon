using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	public class MagentiteBar : ModItem
	{
		public override void SetDefaults()
		{
			item.rare = 2;
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 380;
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.MagentiteBar>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<MagentiteOre>(), 4);
			recipe.AddTile(17);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}