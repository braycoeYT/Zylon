using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BloodstainedLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.03f;
			player.whipRangeMultiplier += 0.1f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}