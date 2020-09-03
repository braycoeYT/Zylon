using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ComputerVirus
{
	public class MechanicalDisc : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Floppy Disc");
			Tooltip.SetDefault("It wants to be plugged into your computer\nSummons Computer Virus");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 20;
			item.value = 0;
			item.rare = ItemRarityID.Orange;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if(!Main.dayTime)
			{
				if(!NPC.AnyNPCs(mod.NPCType("ComputerVirus")))
				return !NPC.AnyNPCs(mod.NPCType("ComputerVirusPha2"));
				return false;
			}
			return false;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.ComputerVirus>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 4);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.SoulofFlight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}