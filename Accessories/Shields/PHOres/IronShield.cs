using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Shields.PHOres
{
	public class IronShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Shield");
			Tooltip.SetDefault("Mine until you die\nIncreases mining speed by 7%");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 20000;
			item.rare = 0;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed += 0.07f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}