using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class WoodenShield : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'You've got to start somewhere'");
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.accessory = true;
			Item.value = 100;
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}