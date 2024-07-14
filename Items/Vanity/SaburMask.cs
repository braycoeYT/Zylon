using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class SaburMask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.value = Item.sellPrice(0, 7, 5);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.vanity = true;
		}
	}
}