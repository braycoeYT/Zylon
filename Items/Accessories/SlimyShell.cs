using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SlimyShell : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 24;
			Item.value = Item.sellPrice(0, 0, 85);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}
		int extraMana;
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_SlimyShell) {
				if (extraMana == 0 && player.statMana >= player.statManaMax2 - 5) {
					extraMana = 40;
				}
				else if (extraMana > 0 && player.statMana < player.statManaMax2) extraMana = 0;
				
				player.statManaMax2 += extraMana;
			}
			p.CHECK_SlimyShell = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Seashell, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}