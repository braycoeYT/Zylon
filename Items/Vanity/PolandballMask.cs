using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class PolandballMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Can Polandball into space?'");
		}
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.Blue;
			Item.vanity = true;
		}
	}
}