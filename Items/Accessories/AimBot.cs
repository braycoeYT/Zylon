using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class AimBot : ModItem
	{
        public override void SetDefaults() {
			Item.width = 16;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 20);
			Item.rare = ItemRarityID.LightPurple;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.aimBot = true;
			player.GetDamage(DamageClass.Ranged) -= 0.15f;
		}
	}
}