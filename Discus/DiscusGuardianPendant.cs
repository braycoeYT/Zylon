using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class DiscusGuardianPendant : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'All of the Discuses are watching over you'\nNo Knockback or Fall Damage, +3% Endurance\nThe Discuses' watching pressures you and decreases speed a bit");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 18965;
			item.rare = 2;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance += 0.03f;
			player.noFallDmg = true;
			player.noKnockback = true;
			player.maxRunSpeed -= player.maxRunSpeed * 0.12f;
			player.runAcceleration -= player.runAcceleration * 0.12f;
			player.moveSpeed -= player.moveSpeed * 0.12f;
		}
	}
}