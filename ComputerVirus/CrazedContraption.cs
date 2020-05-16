using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ComputerVirus
{
	public class CrazedContraption : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Beginning to understand this would be your downfall.\nMax wingtime is doubled at the cost of a bit of Max HP and ATK");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.rare = 6;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.allDamage -= 0.1f;
			player.statLifeMax2 -= player.statLifeMax2 / 5;
			player.wingTimeMax += player.wingTimeMax;
		}
	}
}