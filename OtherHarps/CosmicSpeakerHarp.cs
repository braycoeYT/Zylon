using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class CosmicSpeakerHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Every pluck on this harp creates a new star'");
		}

		public override void SetDefaults() 
		{
			item.damage = 129;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 100000;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 13;
			item.holdStyle = 3;
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