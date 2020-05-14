using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class Cactirang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Throw infinite cacti");
		}
		
		public override void SetDefaults() 
		{
			item.damage = 6;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 72;
			item.useAnimation = 72;
			item.useStyle = 4;
			item.knockBack = 4.5f;
			item.value = 500;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Cactirang");
			item.shootSpeed = 8f;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 11);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}