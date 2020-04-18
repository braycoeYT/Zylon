using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class Stalactite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Slice'em up!");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.value = 29990;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.MarbleBlock, 10);
			recipe.AddIngredient(ItemID.GraniteBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}