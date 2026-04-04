using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Placeables.Furniture
{
	public class SoulofByteinaBottle : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.Furniture.SoulofByteinaBottle>();
			Item.width = 14;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 0, 0, 30);
			Item.rare = ItemRarityID.White;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ModContent.ItemType<Materials.SoulofByte>());
			recipe.Register();
		}
	}
}