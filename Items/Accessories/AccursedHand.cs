using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class AccursedHand : ModItem
	{
        public override void SetDefaults() {
			Item.width = 32;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 10);
			Item.rare = ItemRarityID.Orange;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.accursedHand = true;
		}
	}
}