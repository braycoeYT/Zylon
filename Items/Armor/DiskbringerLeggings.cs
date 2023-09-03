using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DiskbringerLegpieces : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Grants immunity to desert winds");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.WindPushed] = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}