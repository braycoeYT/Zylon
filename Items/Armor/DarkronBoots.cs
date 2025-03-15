using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DarkronBoots : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 15;
		}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Generic) += 0.09f;
			player.moveSpeed += 0.09f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}