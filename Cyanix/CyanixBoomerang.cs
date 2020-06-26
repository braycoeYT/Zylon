using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	public class CyanixBoomerang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Throw infinite boomerangs");
		}
		
		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 4;
			item.knockBack = 6.5f;
			item.value = 12000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("CyanixBoomerang");
			item.shootSpeed = 10f;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}