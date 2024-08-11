using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class EnchantedPocketwatch : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperWatch);
			recipe.AddIngredient(ItemID.Obsidian, 11);
			recipe.AddIngredient(ItemID.FallenStar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TinWatch);
			recipe.AddIngredient(ItemID.Obsidian, 11);
			recipe.AddIngredient(ItemID.FallenStar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}