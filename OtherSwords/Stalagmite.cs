using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class Stalagmite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Stab'em up!");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 4.5f;
			item.value = 21005;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 20);
			recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.GraniteBlock, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}