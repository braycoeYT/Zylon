using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Placeables
{
	public class JadeStoneBlock : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Jade>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 1);
			Item.rare = ItemRarityID.White;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock);
			recipe.AddIngredient(ItemType<Materials.Jade>());
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.AddCondition(Condition.InGraveyard);
			recipe.Register();
		}
	}
}