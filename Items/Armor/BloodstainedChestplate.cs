using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodstainedChestplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 35);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.04f;
			player.maxMinions += 1;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 13);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}