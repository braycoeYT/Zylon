using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class PyrotechFencingBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'The Fiery Greatsword's older brother'");
		}

		public override void SetDefaults() 
		{
			item.damage = 81;
			item.melee = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 15000;
			item.rare = 5;
			item.UseSound = SoundID.Item14;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 2;
			item.shoot = 85;
			item.shootSpeed = 6;
			item.shopCustomPrice = 30000;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(121);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofMight, 4);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}