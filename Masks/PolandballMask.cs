using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Masks
{
	[AutoloadEquip(EquipType.Head)]
	public class PolandballMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can Polandball into space?");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 500000;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(116, 179, 237);
                }
            }
        }
	}
}