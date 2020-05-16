using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cyanix
{
	public class CyanixHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Quite a fast harp");
		}

		public override void SetDefaults() 
		{
			item.damage = 5;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.knockBack = 0.5f;
			item.value = 100000;
			item.rare = 0;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 4.5f;
			item.noMelee = true;
			item.mana = 2;
			item.holdStyle = 3;
			item.stack = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}