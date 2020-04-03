using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class BraycoeBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braycoe's Boots");
			Tooltip.SetDefault("Not very worn at all!\nHyper speed is yours now\nGet an extraordinary headstart with the shield of cthulhu and similar items\n+30 max wing time");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 175849;
			item.rare = 11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxRunSpeed += 20f;
			player.wingTimeMax += 30;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(mod.ItemType("BraycoeSludge"), 20);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}