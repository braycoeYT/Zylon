using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class FlamingScent : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flaming Scent");
			Tooltip.SetDefault("They really don't want to attack you now\nEnemies are less likely to target you\n5% increased damage and critical strike chance\nInflicts fire damage on attack");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 110000;
			item.rare = ItemRarityID.LightPurple;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.aggro -= 400;
			player.allDamage += 0.05f;
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
			player.magmaStone = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PutridScent);
			recipe.AddIngredient(ItemID.MagmaStone);
			recipe.AddIngredient(ItemID.SoulofFright, 8);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}