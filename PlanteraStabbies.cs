using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class PlanteraStabbies : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Plant based knifes for the kitchen that doesn't mess around\nCan venom enemies");
		}

		public override void SetDefaults() 
		{
			item.damage = 57;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.knockBack = 2.1f;
			item.value = 75;
			item.rare = 6;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("PlanteraStabby");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PlanteraTooth"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 250);
			recipe.AddRecipe();
		}
	}
}