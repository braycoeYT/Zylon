using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class WadofSpores : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wad of Spores");
			Tooltip.SetDefault("Increases max blowpipe charge by 10\nAt default max blowpipe charge, releases a wad of spores that explodes into more spores on impact");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.blowpipeMaxInc += 10;
			p.wadofSpores = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RichMahogany, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}