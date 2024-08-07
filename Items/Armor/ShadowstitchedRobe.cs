using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShadowstitchedRobe : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 7;
		}
		public override void UpdateEquip(Player player) {
			player.manaCost -= 0.08f;
			player.GetCritChance(DamageClass.Magic) += 8;
			player.GetDamage(DamageClass.Magic) += 0.08f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TatteredRobe>());
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>(), 12);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 6);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}