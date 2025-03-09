using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class HitmansCharm : ModItem
	{
        public override void SetDefaults() {
			Item.width = 42;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 15);
			Item.rare = ItemRarityID.LightRed;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.hitmansCharm = true;
		}
	}
}