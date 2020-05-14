using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class GigaGemstone : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Giga Gemstone");
			Tooltip.SetDefault("One of the most valuable gems ever\nSummons the mineral extractor of countless worlds at night...\nNot Consumable");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 5000000;
			item.rare = 10;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = false;
		}
		
		public override bool CanUseItem(Player player)
		{
			if(!Main.dayTime)
				if(!NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractor")))
					return !NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractorPha2"));
				return false;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.ZylonianMineralExtractor>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MysteriousGemBlue"));
			recipe.AddIngredient(mod.ItemType("MysteriousGemGreen"));
			recipe.AddIngredient(mod.ItemType("MysteriousGemPink"));
			recipe.AddIngredient(mod.ItemType("MysteriousGemRed"));
			recipe.AddIngredient(mod.ItemType("MysteriousGemWhite"));
			recipe.AddIngredient(mod.ItemType("MysteriousGemYellow"));
			recipe.AddIngredient(mod.ItemType("DreamString"), 20);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 15);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}