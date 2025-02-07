using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LivingWoodMask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.White;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LivingWoodBreastplate>() && legs.type == ModContent.ItemType<LivingWoodLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetKnockback(DamageClass.Summon) += 0.05f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.LivingWoodMask.SetBonus");
			player.maxMinions += 3;
			player.GetDamage(DamageClass.Summon) -= 0.5f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 7);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}