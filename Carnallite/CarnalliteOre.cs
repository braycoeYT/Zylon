using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Carnallite
{
	public class CarnalliteOre : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Works well with floral matter");
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Carnallite.CarnalliteOre>();
			item.width = 12;
			item.height = 12;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = ItemRarityID.Lime;
		}
	}
}