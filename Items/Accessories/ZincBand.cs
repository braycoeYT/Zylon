using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class ZincBand : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases the potency of Swiftness Potions");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 48, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bandofZinc = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}