using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ZincBreastplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 16, 0);
			Item.defense = 3;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}