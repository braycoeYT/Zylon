using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Banners
{
	public class WindElementalBanner : ModItem
	{
		public override void SetDefaults() {
			Item.width = 14;
            Item.height = 36;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.createTile = ModContent.TileType<Tiles.Banners.MonsterBanner>();
            Item.placeStyle = 16;
		}
	}
}