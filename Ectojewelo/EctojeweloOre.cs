using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloOre : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A very rare and powerful ore");
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Ectojewelo.EctojeweloOre>();
			item.width = 12;
			item.height = 12;
			item.value = Item.sellPrice(0, 0, 20, 0);
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