using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories.Shields
{
	public class WoodenShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wooden Shield");
			Tooltip.SetDefault("You've got to start somewhere");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.accessory = true;
			item.value = 5000;
			item.rare = 0;
			item.defense = 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}