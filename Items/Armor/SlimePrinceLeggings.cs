using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SlimePrinceLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Only second to the king himself'\nIncreases summoner damage by 3%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 15);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.03f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 6);
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}