using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class BloodContract : ModItem
	{
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 75);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bloodContract = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 11);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 15);
			recipe.AddIngredient(ItemID.BlackInk);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 11);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 15);
			recipe.AddIngredient(ItemID.BlackDye, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}