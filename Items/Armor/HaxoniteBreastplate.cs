using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HaxoniteBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases life and mana regeneration by 1");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 60);
			Item.rare = ItemRarityID.Green;
			Item.defense = 10;
		}
		public override void UpdateEquip(Player player) {
			player.lifeRegen += 1;
			player.manaRegen += 1;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 20);
			recipe.AddIngredient(ItemID.MeteoriteBar, 6);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}