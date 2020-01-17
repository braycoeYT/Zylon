using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class AncientDiscusHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'The Ancient Discus's great speeds are easily shown through this harp.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 600;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 8.5f;
			item.noMelee = true;
			item.mana = 4;
			item.holdStyle = 3;
			item.stack = 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}