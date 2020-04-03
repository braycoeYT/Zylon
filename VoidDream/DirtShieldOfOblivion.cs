using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.VoidDream
{
	public class DirtShieldOfOblivion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Shield of Oblivion");
			Tooltip.SetDefault("Immune to Weak\n+1% all damage\n-10% Movement Speed\n1% Chance to take 1 damage\nVoid Dream");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 15000;
			item.rare = -1;
			item.expert = true;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[33] = true;
			player.allDamage += 0.01f;
			player.maxRunSpeed -= 0.1f;
			if (Main.rand.NextFloat() < .01f)
			{
				player.endurance += 100;
			}
			else
			{
				player.endurance += 0;
			}
		}
	}
}