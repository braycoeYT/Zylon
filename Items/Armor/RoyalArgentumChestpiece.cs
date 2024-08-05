using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RoyalArgentumChestpiece : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 25);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.defense = 29;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.noKnockback = true;
			p.royalArgentumChestpiece = true;
			player.lifeRegen += 2;
			player.GetDamage(DamageClass.Generic) += 0.15f;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverChainmail);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 5);
			recipe.AddIngredient(ItemID.CobaltShield);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenChainmail);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 5);
			recipe.AddIngredient(ItemID.CobaltShield);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}