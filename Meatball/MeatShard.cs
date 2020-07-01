using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Meatball
{
	public class MeatShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meat Shard");
			Tooltip.SetDefault("This looks like it would be delicious on pasta, for some reason...");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 500;
			item.rare = 0;
			item.maxStack = 999;
		}
	}
}