using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class PlainNoodle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plain Noodle");
			Tooltip.SetDefault("Does ???.\nIt is not using its full potential.");
		}

		public override void SetDefaults()
		{
			item.width = 29;
			item.height = 15;
			item.accessory = true;
			item.value = 1000;
			item.rare = ItemRarityID.Orange;
			item.maxStack = 99;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += item.stack;
			player.statLifeMax2 += item.stack * 5;
			player.statDefense -= item.stack;
			player.endurance -= item.stack / 100;
		}
	}
}