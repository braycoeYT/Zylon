using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace Zylon.Items.Accessories
{
	public class DoublePluggedCord : ModItem
	{
        public override void SetDefaults() {
			Item.width = 46;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4, 75);
			Item.rare = ItemRarityID.Yellow;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "Hold " + "(Double Plugged Cord Keybind)" + " to supercharge yourself\nSupercharging will drain your life, but recover mana extremely quickly\nWhile supercharging, magic damage is boosted by 25%");
			list.Add(xline);
        }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.doublePluggedCord = true;
		}
	}
}