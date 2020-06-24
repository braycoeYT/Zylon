using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class ShardOfPrejudice : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shard of Prejudice");
			Tooltip.SetDefault("No, it is not a doughnut and no, you cannot eat it!\nUsing a javelance will launch a bleeding javelance which rains bleeding orbs");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 21000;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.redJavelance = true;
		}
	}
}