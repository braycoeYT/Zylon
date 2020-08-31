using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class GalacticDiamondium : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It appears to be a part of the mineral extractor,\nbut it seems that it has been tinkered with too much to return to its original state.");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 90, 0);
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