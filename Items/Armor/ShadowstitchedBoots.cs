using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShadowstitchedBoots : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 2, 25);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 7;
		}
		public override void UpdateEquip(Player player) {
			player.manaCost -= 0.07f;
			player.GetCritChance(DamageClass.Magic) += 8;
			player.GetDamage(DamageClass.Magic) += 0.08f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TatteredSkirt>());
			recipe.AddIngredient(ModContent.ItemType<Materials.TabooEssence>(), 10);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}