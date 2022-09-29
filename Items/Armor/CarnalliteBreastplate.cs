using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CarnalliteBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases run speed by 10%\nIncreases max life by 20");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 8;
		}
		public override void UpdateEquip(Player player) {
			player.statLifeMax2 += 20;
			player.runAcceleration += 0.02f;
			player.maxRunSpeed += 0.1f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 24);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}