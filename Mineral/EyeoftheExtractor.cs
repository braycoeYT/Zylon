using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class EyeoftheExtractor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Extractor");
			Tooltip.SetDefault("After equiping this, those gems are starting to look edible...\nIncreases jump speed by 500%\nDecreases Xenic Acid debuff damage by 25%\nKilling enemies causes them to drop galactic souls, which give you a powerful buff\nCancels negative effects of gemstone armor");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = item.value = Item.sellPrice(0, 12, 0, 0);
			item.rare = 11;
			item.expert = true;
			item.defense = 2;
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
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.mineralExpert = true;
			player.jumpSpeedBoost += 5f;
			player.allDamage += Math.Abs(player.velocity.X) / 100;
			player.statDefense += (int)Math.Abs(player.velocity.Y);
		}
	}
}