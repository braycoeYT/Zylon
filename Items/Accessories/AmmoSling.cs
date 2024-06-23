using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class AmmoSling : ModItem
	{
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 74);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.ammoSling = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale");
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}