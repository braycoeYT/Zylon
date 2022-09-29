using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ZincLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 13, 0);
			Item.defense = 2;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 16);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}