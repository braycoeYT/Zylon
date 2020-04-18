using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class AncientDiscusBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It summons sand daggers and is known for being an antlion hunting weapon'");
		}

		public override void SetDefaults() 
		{
			item.damage = 11;
			item.melee = true;
			item.width = 39;
			item.height = 39;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 6000;
			item.rare = 0;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 93;
			item.shootSpeed = 6;
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