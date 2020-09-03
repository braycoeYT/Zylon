using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories.Shields
{
	public class LifeforceShield : ModItem 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lifeforce Shield");
			Tooltip.SetDefault("Increases life regen by 1\nIncreases max life by 10");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 26;
			item.accessory = true;
			item.value = 65000;
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 10;
			player.lifeRegen += 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 7);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}