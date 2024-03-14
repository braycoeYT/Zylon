using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bars
{
	public class CarnalliteBar : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Green;
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 8, 0);
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Bars.CarnalliteBar>();
			Item.placeStyle = 0;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Ores.CarnalliteOre>(), 4);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}