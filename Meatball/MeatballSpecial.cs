using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatballSpecial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meatball Special");
			Tooltip.SetDefault("Meatballs are replaced by big meatballs\nBig meatballs venom enemies instead of poison");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 45000;
			item.rare = 3;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.UpgradeMeatball = true;
		}
	}
}