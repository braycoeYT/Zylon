using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class MaxHPCheat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Max HP Cheat");
			Tooltip.SetDefault("Stuf 4 testin");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 110000;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 200000;
		}
	}
}