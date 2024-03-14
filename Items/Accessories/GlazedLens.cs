using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class GlazedLens : ModItem
	{
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetCritChance(DamageClass.Generic) += 4;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.glazedLens = true;
		}
	}
}