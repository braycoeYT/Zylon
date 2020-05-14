using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.PHBoss
{
	public class OrganicBone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Organic Bone");
			Tooltip.SetDefault("Extra Crunchy!\nDecreases enemy aggression");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 7500;
			item.rare = 2;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.aggro -= 100;
		}
	}
}