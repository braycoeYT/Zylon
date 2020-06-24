using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSlappys
{
	public class Night : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Represents a time of horror and fright...'");
		}

		public override void SetDefaults() 
		{
			item.damage = 13;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 500;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddIngredient(ItemID.CopperBar, 4);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddIngredient(ItemID.TinBar, 4);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}