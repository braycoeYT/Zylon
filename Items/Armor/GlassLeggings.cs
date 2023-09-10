using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlassLeggings : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("-4 Defense\n'Make sure no one throws any stones at you'\nIncreases weapon speed by 5%");
=======
			// Tooltip.SetDefault("-4 Defense\n'Make sure no one throws any stones at you'\nIncreases weapon speed by 5%");
>>>>>>> ProjectClash
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = -4;
		}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Generic) += 0.05f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 20);
			recipe.AddIngredient(ItemID.Obsidian);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}