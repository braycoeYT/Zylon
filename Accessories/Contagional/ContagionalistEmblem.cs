using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Contagional
{
	public class ContagionalistEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased Contagional Damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 20000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalDamageMult += 0.15f;
		}
	}
}