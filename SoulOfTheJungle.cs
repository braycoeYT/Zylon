using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class SoulOfTheJungle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Jungle");
			Tooltip.SetDefault("+25 Max HP\nSummons spores over time that will damage enemies\nGreatly increases life regen when not moving\nReleases bees when damaged\nIncreases the strength of friendly bees");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 215748;
			item.rare = 11;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 25;
			player.SporeSac();
			player.sporeSac = true;
			player.shinyStone = true;
			player.strongBees = true;
			player.bee = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(3333);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.LifeFruit, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}