using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class WoodenVirus : ContagionalItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Is this thing alive? Scientists are always debating over the virus community.'\n~~~100% chance of inflicting poison for 4 seconds");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 5;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 111;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("WoodenVirus");
			item.shootSpeed = 8;
			ContagionalResourceCost = 3;
			item.crit = 4;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}