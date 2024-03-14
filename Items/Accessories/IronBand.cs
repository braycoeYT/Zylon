using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class IronBand : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bandofMetal = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}