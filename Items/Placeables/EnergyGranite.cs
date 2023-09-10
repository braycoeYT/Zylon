using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Tiles.Granite;

namespace Zylon.Items.Placeables
{
	public class EnergyGranite : ModItem
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
			Item.createTile = ModContent.TileType<Tiles.Granite.EnergyGranite>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.White;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Granite, 1);
			recipe.AddTile(ModContent.TileType<EnergizedStone>());
			recipe.Register();
		}
	}
}
