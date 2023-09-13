using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class BigOlBouquet : ModItem
	{
		public override void SetDefaults() { //btw set heal chance to 13% bc its on the fibonacci sequence which is related to flowers (also I LOVE 13 WOOO)
			Item.width = 48;
			Item.height = 54;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.bigOlBouquet = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddRecipeGroup("Zylon:AnyHerb", 12);
			recipe.Register();
		}
	}
}