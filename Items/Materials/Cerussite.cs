using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Materials
{
	public class Cerussite : ModItem
	{
		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.Cerussite>();
			Item.width = 26;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.White;
		}
	}
}