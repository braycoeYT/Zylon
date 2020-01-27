using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class SuspiciousLookingDisc : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'You stare at it, and it stares back at you... Only usable in the desert night'");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 0;
			item.rare = 2;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
			item.shopCustomPrice = 5000;
		}
		
		public override bool CanUseItem(Player player)
		{
			if(player.ZoneDesert)
				if(!Main.dayTime)
					return !NPC.AnyNPCs(mod.NPCType("AncientDesertDiscus"));
				return false;
			return false;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>());
			if (Main.expertMode)
			{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Minions.SandGrainDiscus>());
			}
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 1);
			recipe.AddIngredient(ItemID.SandBlock, 15);
			recipe.AddIngredient(ItemID.AntlionMandible, 3);
			recipe.AddIngredient(ItemID.Cactus, 5);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 9);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}