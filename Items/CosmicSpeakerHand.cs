using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class CosmicSpeakerHand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It shoots a supernova, or rather a supernova-powered firework.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 99;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 100000;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 168;
			item.shootSpeed = 6f;
			item.stack = 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DreamString"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}