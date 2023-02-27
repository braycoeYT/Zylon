using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SlimePrinceBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Only second to the king himself'\nIncreases summoner damage by 4%\nIncreases your max number of minions by 1");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.04f;
			player.maxMinions += 1;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 5);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 7);
			recipe.AddIngredient(ItemID.Gel, 45);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}