using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShroomiteHeaddress : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 7, 50);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 11;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.ShroomiteBreastplate && legs.type == ItemID.ShroomiteLeggings;
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			//player.GetDamage(DamageClass.Ranged) += 0.08f;
			//player.GetCritChance(DamageClass.Ranged) += 5;
			p.blowpipeMaxInc += 50;
			p.blowpipeChargeInc = 1f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.ShroomiteHeaddress.SetBonus");
			player.shroomiteStealth = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteHelmet);
			recipe.AddIngredient(ItemID.GlowingMushroom, 180);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}