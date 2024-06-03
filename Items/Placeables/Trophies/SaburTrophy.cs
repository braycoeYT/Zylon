using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Zylon.Items.Placeables.Trophies
{
	public class SaburTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Trophies.SaburTrophy>());
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.rare = ModContent.RarityType<Magenta>();
			Item.value = Item.sellPrice(0, 10);
		}
	}
}