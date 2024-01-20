using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NeutronTracers : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 10, 50);
			Item.rare = ItemRarityID.Red;
			Item.defense = 14;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.neutronTracers = true;
			if (player.statLife < player.statLifeMax2*0.25f) player.GetCritChance(DamageClass.Melee) += 8;
			if (player.statLife < player.statLifeMax2*0.125f) player.GetCritChance(DamageClass.Melee) += 5;
			if (player.velocity.Length() == 0f) player.GetDamage(DamageClass.Ranged) += 0.2f;
			player.manaRegen += 2;
			player.whipRangeMultiplier += 0.25f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 10);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}