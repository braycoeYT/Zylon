using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Zylon.Items.Vanity.Dev
{
	[AutoloadEquip(EquipType.Legs)]
	public class BraycoeLegs : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ModContent.RarityType<BraycoeDev>();
			Item.vanity = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "~Developer Item (Braycoe)~");
			xline.OverrideColor = new Color(116, 179, 237);
			list.Add(xline);
        }
	}
}