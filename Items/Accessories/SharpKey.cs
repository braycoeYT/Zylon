using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SharpKey : ModItem
	{
		public override void SetDefaults() {
			Item.width = 50;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
		}
        public override void UpdateInventory(Player player) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.sharpKey = true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AshWood, 24);
			recipe.AddIngredient(ItemID.Obsidian, 13);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}