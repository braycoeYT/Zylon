using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class GemstoneTossblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Toss a lil stabber");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 197;
			item.width = 33;
			item.height = 33;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 3.5f;
			item.value = 162000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GemstoneTossblade");
			item.shootSpeed = 4f;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}