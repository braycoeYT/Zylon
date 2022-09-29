using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ores
{
	public class ZincOre : ModItem
	{
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Ores.ZincOre>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 1, 60);
			Item.rare = ItemRarityID.White;
		}
	}
}