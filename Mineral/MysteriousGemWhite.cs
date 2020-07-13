using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class MysteriousGemWhite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mysterious Gem");
			Tooltip.SetDefault("'Its beauty is priceless...' Summons the mineral extractor of countless worlds at night...");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 500000;
			item.rare = 10;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
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
			recipe.AddIngredient(ItemID.Diamond, 2);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}