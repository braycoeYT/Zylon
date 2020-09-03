using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories.Shields
{
	public class StoneShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Shield");
			Tooltip.SetDefault("The obvious next step from wood");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.accessory = true;
			item.value = 7500;
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}