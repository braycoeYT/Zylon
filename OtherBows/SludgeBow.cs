using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherBows
{
	public class SludgeBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It somehow doesn't melt in your hands'");
		}

		public override void SetDefaults() 
		{
			item.value = 20;
			item.useStyle = 5;
			item.useAnimation = 26;
			item.useTime = 26;
			item.damage = 8;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1;
			item.shoot = 1;
			item.shootSpeed = 6.3f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 5;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}