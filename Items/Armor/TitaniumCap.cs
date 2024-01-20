using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumCap : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
		}
        public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Summon) += 0.9f;
			player.maxMinions += 1;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "Your max number of minions is increased by 1\nAttacking generates a defensive barrier of titanium shards";
			player.onHitTitaniumStorm = true;
			player.maxMinions += 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}