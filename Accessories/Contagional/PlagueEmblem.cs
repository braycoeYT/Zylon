using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Contagional
{
	public class PlagueEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("13% increased Contagional Damage\n+10% Contagional Crit\n+20% Contagional Knockback");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 95000;
			item.rare = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalDamageMult += 0.13f;
			modPlayer.ContagionalCrit += 10;
			modPlayer.ContagionalKnockback += modPlayer.ContagionalKnockback * 0.2f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 10);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}