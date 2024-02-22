using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bars
{
	public class ZincBar : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Can be used in Any Iron Bar recipes");
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.White;
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 4, 80);
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Bars.ZincBar>();
			Item.placeStyle = 0;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Ores.ZincOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}