using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class MeatEye : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This...this is stupid.\n+25 HP but -2% Speed");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 2700;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxRunSpeed -= 0.02f;
			player.runAcceleration -= player.runAcceleration * 0.02f;
			player.moveSpeed -= player.moveSpeed * 0.02f;
			player.statLifeMax2 += 25;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("VileEye"));
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}