using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class HarpysCrest : ModItem
	{
		public override void SetDefaults() {
			Item.width = 58;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
			Item.channel = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.controlUp)
			player.slowFall = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ItemID.Feather, 15);
			recipe.AddIngredient(ItemID.FeatherfallPotion, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}