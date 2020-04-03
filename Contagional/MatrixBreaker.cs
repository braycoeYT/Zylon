using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public class MatrixBreaker : ContagionalItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Matrix Breaker");
			Tooltip.SetDefault("'Usage of this item may or may not corrupt you universe, let alone your world.'\n~~~50% chance of inflicting venom for 1 second\n~~~50% chance of inflicting ichor for 1 second");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 97;
			item.width = 33;
			item.height = 33;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 0f;
			item.value = 85000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("MatrixBreaker");
			item.shootSpeed = 13;
			item.crit = 2;
			ContagionalResourceCost = 16;
			item.noUseGraphic = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}