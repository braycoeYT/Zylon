using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class BrassRing : ModItem
	{
        public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2, 50);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.moveSpeed += 0.15f;
			p.brassRing = true;
		}
	}
}