using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class FrostBite : ContagionalItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A virus that has similar effects to real frostbite'\n~~~40% Chance of inflicting Frostburn for 5 seconds");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 6;
			item.width = 33;
			item.height = 33;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 1.5f;
			item.value = 738;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("FrostBite");
			item.shootSpeed = 11;
			ContagionalResourceCost = 4;
			item.crit = 6;
			item.noUseGraphic = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 10);
			recipe.AddIngredient(ItemID.RottenChunk);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 10);
			recipe.AddIngredient(ItemID.Vertebrae);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}