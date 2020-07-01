using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class KaizoMedal : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The Void's treasure and your torture'\nYou take a lot more damage and defense is halved\nAll crit is crippled and minion knockback is almost zero\nLife and Mana are corrupted and don't work as well\nThe void severely reduces your movement speed\nWings are a lot worse\nObviously you lose an accessory slot");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.rare = -1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 1;
			player.statDefense -= player.statDefense / 2;
			player.meleeCrit = player.meleeCrit / 6;
			player.rangedCrit = player.rangedCrit / 6;
			player.magicCrit = player.magicCrit / 6;
			player.minionKB = -999;
			player.thrownCrit = player.thrownCrit / 6;
			player.statLifeMax2 -= player.statLifeMax2 / 3;
			player.statManaMax2 -= player.statManaMax2 / 3;
			player.maxRunSpeed -= player.maxRunSpeed * 0.25f;
			player.runAcceleration -= player.runAcceleration * 0.5f;
			player.moveSpeed -= player.moveSpeed * 0.25f;
			player.wingTimeMax -= player.wingTimeMax / 2;
		}
	}
}