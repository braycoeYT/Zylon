using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LivingWoodBreastplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override void UpdateEquip(Player player) {
			player.GetKnockback(DamageClass.Summon) += 0.08f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 11);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}