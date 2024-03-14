using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class JadeRobe : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 25);
			Item.rare = ItemRarityID.Green;
			Item.defense = 1;
		}
        public override void UpdateEquip(Player player) {
			player.statManaMax2 += 40;
			player.manaCost -= 0.08f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Robe);
			recipe.AddIngredient(ModContent.ItemType<Materials.Jade>(), 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}