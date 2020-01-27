using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class MysteriousGem : ModItem
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
			if(!Main.dayTime)
				if(!NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractor")))
					return !NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractorPha2"));
				return false;
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
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(mod.ItemType("DarkSoul"), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}