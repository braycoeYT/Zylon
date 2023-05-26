using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class AirTank : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Hot buy amongst the elderly, scuba divers, and fans of currency overprinting!'\nIncreases blowpipe charge speed by 15/s\nIncreases blowpipe shoot speed by 10%");//\nIncreases blowpipe max charge shoot speed by 999");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Pink;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.blowpipeChargeInc += 0.5f;
			p.blowpipeChargeShootSpeedMult += 0.1f;
		}
		/*public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddIngredient(ItemID.PixieDust, 10);
			recipe.AddIngredient(ItemID.SoulofFlight, 15);
			recipe.AddIngredient(ItemID.Cloud, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}*/
	}
}