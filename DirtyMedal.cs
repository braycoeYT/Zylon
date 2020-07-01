using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class DirtyMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+5% Movement Speed\n+10 Max Life");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 600;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 10;
			player.maxRunSpeed += 0.05f;
		}
	}
}