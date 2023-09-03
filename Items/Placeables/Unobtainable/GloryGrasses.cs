using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Tiles;

namespace Zylon.Items.Placeables.Unobtainable
{

	public class GloryGrasses : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Testing and building purposes only.\nUnobtainable.");
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.Marble.GloryGrasses>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.White;
		}
	}
}
