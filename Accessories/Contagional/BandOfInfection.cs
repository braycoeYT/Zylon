using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Contagional
{
	public class BandOfInfection : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Band of Infection");
			Tooltip.SetDefault("Max Contagional Points are increased by 50");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 10000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalResourceMax2 += 50;
		}
	}
}