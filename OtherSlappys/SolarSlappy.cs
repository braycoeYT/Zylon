using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSlappys
{
	public class SolarSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoots a fireball");
		}

		public override void SetDefaults() 
		{
			item.damage = 146;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 111110;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 15;
			item.shootSpeed = 21f;
			item.stack = 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}