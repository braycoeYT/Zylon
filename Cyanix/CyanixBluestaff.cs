using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cyanix
{
	public class CyanixBluestaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Spam blue bolts onto your enemies");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 9500;
			item.rare = 0;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 123;
			item.shootSpeed = 5f;
			item.noMelee = true;
			item.mana = 5;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}