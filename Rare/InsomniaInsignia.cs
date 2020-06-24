using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Rare
{
	public class InsomniaInsignia : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I get no sleep\nIncreases melee speed by 50% but decreases all damage by 29%\nRare Item");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 78000;
			item.rare = -11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += 0.5f;
			player.allDamage -= 0.29f;
		}
	}
}