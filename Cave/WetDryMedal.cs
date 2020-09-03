using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cave
{
	public class WetDryMedal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wet-Dry Medal");
			Tooltip.SetDefault("Users of the Wet-Dry Medal have experienced unexplainable stress, use with caution\nAll stats increase as you progress\nIncreases all damage and armor penetration but decreases defense and damage reduction a bit");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 250000;
			item.rare = ItemRarityID.Orange;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (NPC.downedMoonlord)
			{
				player.allDamage += 0.42f;
				player.armorPenetration += 25;
				player.statDefense -= 30;
				player.endurance -= 0.18f;
			}
			else if (Main.hardMode)
			{
				player.allDamage += 0.25f;
				player.armorPenetration += 12;
				player.statDefense -= 15;
				player.endurance -= 0.09f;
			}
			else
			{
				player.allDamage += 0.12f;
				player.armorPenetration += 5;
				player.statDefense -= 5;
				player.endurance -= 0.05f;
			}
		}
	}
}