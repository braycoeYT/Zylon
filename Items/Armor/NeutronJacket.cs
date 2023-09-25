using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NeutronJacket : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 14);
			Item.rare = ItemRarityID.Red;
			Item.defense = 16;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.neutronJacket = true;
			player.GetAttackSpeed(DamageClass.Melee) += 0.12f;
			player.statManaMax2 += 40;
			player.maxMinions += 2;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 13);
			recipe.AddIngredient(ItemID.LunarBar, 16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}