using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RoyalArgentumBoots : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 20);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.defense = 17;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			//if (player.rocketBoots < 2) player.rocketBoots = 2; //No one would use this :(
			player.dashType = 1;
			player.moveSpeed += 0.17f;
			player.maxFallSpeed += 7f;
			player.jumpSpeedBoost += 3f;
			player.noFallDmg = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverGreaves);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.Tabi);
			recipe.AddIngredient(ItemID.LuckyHorseshoe);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenGreaves);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.Tabi);
			recipe.AddIngredient(ItemID.LuckyHorseshoe);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}