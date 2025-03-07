using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HaxoniteLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 20);
			Item.rare = ItemRarityID.Green;
			Item.defense = 10;
		}
		public override void UpdateEquip(Player player) {
			player.moveSpeed -= 0.08f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 11);
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}