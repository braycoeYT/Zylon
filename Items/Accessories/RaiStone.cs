using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class RaiStone : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.velocity.X < 0.01f && player.velocity.Y < 0.01f) player.statDefense += 8;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 75);
			recipe.AddTile(TileID.Sawmill);
			recipe.Register();
		}
	}
}