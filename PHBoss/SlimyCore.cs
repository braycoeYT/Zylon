using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.PHBoss
{
	public class SlimyCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimy Core");
			Tooltip.SetDefault("Inflict slime on enemies");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 5000;
			item.rare = 3;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();

			p.SlimyCore = true;
		}
	}
}