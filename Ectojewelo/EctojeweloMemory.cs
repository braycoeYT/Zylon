using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloMemory : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ectojewelo Memory");
			Tooltip.SetDefault("It seems to wish you luck on your future endeavors");
		}

		public override void SetDefaults() 
		{
			item.damage = 41;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 250000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 235;
			item.axe = 32;
			item.tileBoost += 5;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondiumDrill"));
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 11);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}