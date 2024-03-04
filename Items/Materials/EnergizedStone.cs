using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Materials
{
	public class EnergizedStone : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.Granite.EnergizedStone>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.White;
		}
	}
}
