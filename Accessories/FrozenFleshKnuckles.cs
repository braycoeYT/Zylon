using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class FrozenFleshKnuckles : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Frozen Flesh Knuckles");
			Tooltip.SetDefault("Enemies are more likely to target you\nPuts a shell around the owner when below 50% life that reduces damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 110000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 8;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.aggro += 400;
			if ((double)player.statLife <= (double)player.statLifeMax2 * 0.5)
				player.AddBuff(62, 5, true);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FleshKnuckles);
			recipe.AddIngredient(ItemID.FrozenTurtleShell);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}