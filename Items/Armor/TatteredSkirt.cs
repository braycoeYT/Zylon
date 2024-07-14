using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class TatteredSkirt : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 75);
			Item.rare = ItemRarityID.Green;
			Item.defense = 2;
		}
		public override void UpdateEquip(Player player) {
			player.manaCost -= 0.06f;
			player.GetCritChance(DamageClass.Magic) += 4;
			player.GetDamage(DamageClass.Magic) += 0.04f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 12);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.Silk, 7);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
		}
	}
}