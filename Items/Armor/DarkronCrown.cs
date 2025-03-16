using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkronCrown : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<DarkronBreastplate>() && legs.type == ModContent.ItemType<DarkronBoots>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.06f;
			p.summonCritBoost += 0.06f;
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