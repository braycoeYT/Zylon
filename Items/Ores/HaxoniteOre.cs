using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Ores
{
	public class HaxoniteOre : ModItem
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
			Item.createTile = TileType<Tiles.Ores.HaxoniteOre>();
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 0, 50);
			Item.rare = ItemRarityID.Green;
		}
	}
}