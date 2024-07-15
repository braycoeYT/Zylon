using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SorcerersKunai : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 3, 76);
			Item.rare = ItemRarityID.Orange;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.sorcerersKunai = true;
		}
	}
}