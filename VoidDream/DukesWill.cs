using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.VoidDream
{
	public class DukesWill : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke's Will");
			Tooltip.SetDefault("Increases fishing skill a lot");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 25000;
			item.rare = 8;
			item.defense = 1;
			item.maxStack = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fishingSkill += 15;
		}
	}
}