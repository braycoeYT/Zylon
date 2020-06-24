using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Reset
{
	public class MineralReset : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mineral Reset");
			Tooltip.SetDefault("Allows you to refight the Extractor for more ectojewelo spawning");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 50000;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return true;
		}
		
		public override bool UseItem(Player player)
		{
			ZylonWorld.downedMineral = false;
			ZylonWorld.generatedEctojewelo = false;
			return true;
		}
	}
}