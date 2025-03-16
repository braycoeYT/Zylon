using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkronHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 14;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<DarkronBreastplate>() && legs.type == ModContent.ItemType<DarkronBoots>();
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Ranged) += 0.15f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = Language.GetTextValue("Mods.Zylon.Items.DarkronMask.SetBonus");
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			p.darkronSetBonus = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}