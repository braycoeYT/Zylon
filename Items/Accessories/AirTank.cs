using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class AirTank : ModItem
	{
        public override void SetDefaults() {
			Item.width = 32;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Pink;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.blowpipeChargeInc += 0.5f;
			p.blowpipeChargeShootSpeedMult += 0.1f;
		}
	}
}