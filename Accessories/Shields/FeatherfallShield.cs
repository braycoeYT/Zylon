using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Shields
{
	public class FeatherfallShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Featherfall Shield");
			Tooltip.SetDefault("You fall slower");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 7500;
			item.rare = 1;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.slowFall = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 18);
			recipe.AddIngredient(ItemID.RainCloud, 11);
			recipe.AddIngredient(ItemID.Feather, 6);
			recipe.AddIngredient(ItemID.FeatherfallPotion, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}