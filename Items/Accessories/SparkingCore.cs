using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SparkingCore : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 13);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.sparkingCore = true;
		}
	}
}