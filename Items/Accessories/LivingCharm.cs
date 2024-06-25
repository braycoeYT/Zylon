using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class LivingCharm : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 34;
			Item.value = Item.sellPrice(0, 0, 65);
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.04f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 8);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}