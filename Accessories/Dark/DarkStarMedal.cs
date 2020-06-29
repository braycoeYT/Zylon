using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Dark
{
	public class DarkStarMedal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Chip");
			Tooltip.SetDefault("Causes stars and giant darkstars to fall and increases length of invincibility after taking damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 50000;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.darkstarFall = true;
		}
	}
}