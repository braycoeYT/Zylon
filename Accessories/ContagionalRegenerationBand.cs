using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class ContagionalRegenerationBand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagional Regeneration Band");
			Tooltip.SetDefault("Max Contagional Points are increased by 50\nContagional Regen Amount increased by 2");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 10000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalRegenAmount += 2;
			modPlayer.ContagionalResourceMax2 += 50;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BandOfInfection"));
			recipe.AddIngredient(49);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}