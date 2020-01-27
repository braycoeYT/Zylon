using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class SlimeSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It somehow doesn't melt in your hands'");
		}

		public override void SetDefaults() 
		{
			item.damage = 8;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 20;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
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