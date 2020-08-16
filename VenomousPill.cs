using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class VenomousPill : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("I heard if you take a bit of venom each day you can build up a resistance\nImmunity to venom");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 19;
			item.accessory = true;
			item.value = 50000;
			item.rare = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[BuffID.Venom] = true;
		}
	}
}