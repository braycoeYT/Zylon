using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class IronfistMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases true melee damage by 35%");
		}

		public override void SetDefaults() {
			item.width = 50;
			item.height = 50;
			item.accessory = true;
			item.value = 12000;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.trueMelee35 = true;
		}
	}
}