using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class AncientDiscusSlappy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zappy Hand");
			Tooltip.SetDefault("Launches electric bolts");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 2.9f;
			item.value = 25000;
			item.rare = 1;
			item.UseSound = SoundID.Item9;
			item.autoReuse = false;
			item.useTurn = true;
			item.shoot = 440;
			item.shootSpeed = 7f;
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