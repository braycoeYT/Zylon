using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherChairs.PHOres
{
	public class CopperChair : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.OtherChairs.PHOres.CopperChair>();
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 4);
			recipe.AddTile(TileID.Sawmill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}