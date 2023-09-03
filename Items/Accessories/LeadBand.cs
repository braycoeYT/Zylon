using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class LeadBand : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases the potency of Ironskin Potions");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 45, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bandofMetal = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LeadBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}