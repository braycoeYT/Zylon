using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSlappys
{
	public class CopperSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
		    //idk
		}

		public override void SetDefaults() 
		{
			item.damage = 6;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 90;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}