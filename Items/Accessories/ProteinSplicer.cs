using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class ProteinSplicer : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 75);
			Item.rare = ItemRarityID.Green;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[BuffID.Webbed] = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.AddIngredient(ItemID.Wire, 15);
			recipe.AddIngredient(ItemID.Cobweb, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}