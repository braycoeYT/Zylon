using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class IronfistMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases true melee damage by 35%");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 12000;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.trueMelee35 = true;
		}
	}
}