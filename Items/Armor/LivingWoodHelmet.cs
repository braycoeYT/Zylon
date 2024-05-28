using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LivingWoodHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.White;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LivingWoodBreastplate>() && legs.type == ModContent.ItemType<LivingWoodLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.06f;
			player.maxMinions += 1;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Summon damage inflicts a natural curse on foes";
			p.livingWoodSetBonus = true;
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