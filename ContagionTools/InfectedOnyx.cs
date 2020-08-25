using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ContagionTools
{
	public class InfectedOnyx : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A treasure of the microbiome");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 7500;
			item.rare = 11;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
	}
}