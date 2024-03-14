using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class MagicalVaccine : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[148] = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}