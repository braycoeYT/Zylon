using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Xenic
{
	public class XenicCore : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A very compact and powerful core\nHolding this makes you feel like you are being watched...");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(11, 11)); //first is speed, second is amount of frames
		}
		public override void SetDefaults() {
			item.maxStack = 999;
			item.value = 75000;
			item.rare = ItemRarityID.Purple;
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