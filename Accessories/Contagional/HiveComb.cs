using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Contagional
{
	public class HiveComb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Comb");
			Tooltip.SetDefault("Contagional poison is increased by 1 second");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 15000;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.PoisonedBoost += 1;
		}
	}
}