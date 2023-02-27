using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class WindWalkerBoots : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Not to be confused with the Wind Waker'\nIncreases max run speed by 50%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateEquip(Player player) {
			player.maxRunSpeed += 0.5f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>(), 12);
			recipe.AddIngredient(ItemID.Feather, 6);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 6);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();
		}
	}
}