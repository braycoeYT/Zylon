using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class VileEye : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This...this is stupid.\n+10% Speed but -5 HP");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 2500;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxRunSpeed += 0.1f;
			player.runAcceleration += player.runAcceleration * 0.1f;
			player.moveSpeed += player.moveSpeed * 0.1f;
			player.statLifeMax2 -= 5;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatEye"));
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}