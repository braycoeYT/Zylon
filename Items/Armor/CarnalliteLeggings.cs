using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CarnalliteLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases max life by 20\nIncreases damage by 4%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}
		public override void UpdateEquip(Player player) {
			player.runAcceleration += 0.06f;
			player.GetDamage(DamageClass.Generic) += 0.04f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}