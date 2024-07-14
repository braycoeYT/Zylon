using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LivingWoodLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.defense = 1;
		}
		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.1f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 9);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}