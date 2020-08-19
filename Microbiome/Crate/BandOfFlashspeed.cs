using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome.Crate
{
	public class BandOfFlashspeed : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Band of Flashspeed");
			Tooltip.SetDefault("Increases movement speed by 50%");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 75000;
			item.rare = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxRunSpeed += 0.5f;
			player.moveSpeed += 0.5f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddIngredient(mod.ItemType("NucleusShard"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}