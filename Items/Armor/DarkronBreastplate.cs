using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DarkronBreastplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 19;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.maxMinions += 1;
			p.critExtraDmg += 0.1f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 24);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}