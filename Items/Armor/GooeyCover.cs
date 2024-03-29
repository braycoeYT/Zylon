using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GooeyCover : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
			player.GetAttackSpeed(DamageClass.Melee) -= 0.08f;
			player.GetCritChance(DamageClass.Ranged) += 5;
			player.statManaMax2 += 20;
			player.GetKnockback(DamageClass.Summon) += 0.2f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Food.Smore>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}