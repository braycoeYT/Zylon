using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LihzahrdPlatingBreastplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 21;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.11f;
			player.maxMinions += 1;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LihzahrdBrick, 35);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}