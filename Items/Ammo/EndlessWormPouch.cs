using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ammo
{
	public class EndlessWormPouch : ModItem
	{
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 32;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.value = Item.sellPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.ammo = AmmoID.None;
			Item.bait = 25;
		}
		public override void OnConsumeItem(Player player) {
			Item.stack = 2;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Worm, 300);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}