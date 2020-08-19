using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class Mecharang : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Pew pew pew*\n*Does not shoot lasers");
		}

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 49;
			item.width = 45;
			item.height = 45;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1.5f;
			item.value = 72000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Mecharang");
			item.shootSpeed = 17;
			item.crit = 6;
			item.noUseGraphic = true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}