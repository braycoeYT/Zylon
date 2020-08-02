using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class MysteryBag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Spawn a vanilla creature. Which one? Nobody knows!");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 500;
			item.rare = 11;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, Main.rand.Next(580));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}