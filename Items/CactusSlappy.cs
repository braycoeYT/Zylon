using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class CactusSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It somehow doesn't hurt your hands'");
		}

		public override void SetDefaults() 
		{
			item.damage = 7;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 0;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}