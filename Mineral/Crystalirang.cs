using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class Crystalirang : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Bring it on'");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 249;
			item.width = 33;
			item.height = 33;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3.5f;
			item.value = 162000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Crystalirang");
			item.shootSpeed = 14;
			item.crit = 9;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SilverSlayer"));
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}