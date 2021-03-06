using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class DirtyDiscusMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+10% Movement Speed\n+1 Minion\n+10 Max HP");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 6000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
			player.maxRunSpeed += 0.1f;
			player.statLifeMax2 += 10;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DirtyMedal"));
			recipe.AddIngredient(mod.ItemType("DiscusMedal"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}