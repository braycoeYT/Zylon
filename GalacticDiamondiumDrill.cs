using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class GalacticDiamondiumDrill : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'This is part of the legendary Zylonian Mineral Extractor'");
		}

		public override void SetDefaults() 
		{
			item.damage = 39;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 2;
			item.knockBack = 5;
			item.value = 0;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 230;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}