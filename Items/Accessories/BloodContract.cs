using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class BloodContract : ModItem
	{
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 6);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bloodContract = true;
		}
	}
}