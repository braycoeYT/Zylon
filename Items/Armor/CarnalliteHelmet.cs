using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CarnalliteHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<CarnalliteBreastplate>() && legs.type == ModContent.ItemType<CarnalliteLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.04f;
			player.statLifeMax2 += 20;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.CarnalliteHelmet.SetBonus");
			if (player.statLife == player.statLifeMax2)
				player.AddBuff(ModContent.BuffType<Buffs.Armor.LeafShield>(), 60);
			if (player.statLife <= player.statLifeMax2 / 4)
				player.AddBuff(ModContent.BuffType<Buffs.Armor.NaturesPrayer>(), 60);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}