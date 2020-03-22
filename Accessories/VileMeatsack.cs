using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class VileMeatsack : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Absolutely Disgusting'\n+10% Run speed and +25 HP");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 5555;
			item.rare = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxRunSpeed += player.maxRunSpeed * 0.1f;
			player.runAcceleration += player.runAcceleration * 0.1f;
			player.moveSpeed += player.moveSpeed * 0.1f;
			player.statLifeMax2 += 25;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatEye"));
			recipe.AddIngredient(mod.ItemType("VileEye"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}