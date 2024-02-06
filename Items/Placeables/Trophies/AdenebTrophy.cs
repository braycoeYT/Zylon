using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Zylon.Items.Placeables.Trophies
{
	public class AdenebTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.Trophies.AdenebTrophy>());
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1);
		}
	}
}