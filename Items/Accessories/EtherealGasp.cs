using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class EtherealGasp : ModItem
	{
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 46;
			Item.value = Item.sellPrice(0, 4, 87);
			Item.rare = ItemRarityID.Yellow;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.etherealGasp = true;
        }
	}
}