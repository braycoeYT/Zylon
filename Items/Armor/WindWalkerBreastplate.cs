using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class WindWalkerBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Not to be confused with the Wind Waker'\nIncreases attack speed by 10%\nIncreases move speed by 15%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Generic) += 0.1f;
			player.moveSpeed += 0.15f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SunplateBlock, 18);
			recipe.AddIngredient(ItemID.Feather, 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 12);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();
		}
	}
}