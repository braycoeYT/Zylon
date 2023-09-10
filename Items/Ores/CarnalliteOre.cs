using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Ores
{
	public class CarnalliteOre : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'It has a liking for the rich cultures of mud'");
		}
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Ores.CarnalliteOre>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 2, 0);
			Item.rare = ItemRarityID.Green;
		}
	}
}