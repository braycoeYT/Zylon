using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GlassBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("-5 Defense\n'Make sure no one throws any stones at you'\nIncreases damage by 12%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = -5;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.12f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 25);
			recipe.AddIngredient(ItemID.Obsidian);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}