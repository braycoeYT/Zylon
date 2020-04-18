using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class EyeOfPrejudice : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It stares and sucks your soul into a cage of prejudice...is this a good idea?\n-20 HP, +2 Defense, +7.5% Damage");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 1255;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.075f;
			player.rangedDamage += 0.075f;
			player.magicDamage += 0.075f;
			player.minionDamage += 0.075f;
			player.thrownDamage += 0.075f;
			player.statLifeMax2 -= 20;
			player.statDefense += 2;
		}
	}
}