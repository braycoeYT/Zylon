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
			Item.value = Item.sellPrice(0, 1, 75, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.extraFall = 10;
			p.harpysCrest = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ItemID.Feather, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}