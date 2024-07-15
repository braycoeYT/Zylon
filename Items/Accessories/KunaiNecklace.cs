using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class KunaiNecklace : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 34;
			Item.value = Item.sellPrice(0, 4, 56);
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.04f;
			p.sorcerersKunai = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LivingCharm>());
			recipe.AddIngredient(ModContent.ItemType<SorcerersKunai>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}