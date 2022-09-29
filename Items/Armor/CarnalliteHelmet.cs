using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CarnalliteHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases damage by 4%\nIncreases run speed by 10%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<CarnalliteBreastplate>() && legs.type == ModContent.ItemType<CarnalliteLeggings>();
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.04f;
			player.runAcceleration += 0.02f;
			player.maxRunSpeed += 0.1f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "When at max health, increases your defense by 10 and damage by 12%\nWhen below 25% health, increases your life regen by 3";
			if (player.statLife == player.statLifeMax2)
				player.AddBuff(ModContent.BuffType<Buffs.LeafShield>(), 60);
			if (player.statLife <= player.statLifeMax2 / 4)
				player.AddBuff(ModContent.BuffType<Buffs.NaturesPrayer>(), 60);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}