using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteCap : ModItem
	{
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.08f;
			player.maxMinions += 1;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.AdamantiteCap.SetBonus");
			player.GetDamage(DamageClass.Summon) += 0.19f;
			player.GetKnockback(DamageClass.Summon) += 0.19f;
			player.maxMinions += 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}