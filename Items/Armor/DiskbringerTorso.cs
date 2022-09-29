using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DiskbringerTorso : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max life by 10%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
			player.statLifeMax2 = (int)(player.statLifeMax2 * 1.1f);
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 18);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 21);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}