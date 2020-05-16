using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class AncientDiscusBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'For its age, it sure does shoot far'");
		}

		public override void SetDefaults() 
		{
			item.value = 6000;
			item.useStyle = 5;
			item.useAnimation = 26;
			item.useTime = 26;
			item.damage = 13;
			item.width = 12;
			item.height = 24;
			item.knockBack = 7;
			item.shoot = 1;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.ranged = true;
			item.crit = 11;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}