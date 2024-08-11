using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class Timekeeper : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 44;
			Item.value = Item.sellPrice(0, 3, 65);
			Item.rare = ItemRarityID.Yellow;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EnchantedPocketwatch>());
			recipe.AddIngredient(ItemID.Cog, 24);
			recipe.AddIngredient(ItemID.Ectoplasm, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}