using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class BloodContract : ModItem
	{
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 75);
			Item.rare = ItemRarityID.Orange;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetCritChance(DamageClass.Generic) += 3;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.bloodContract = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TatteredCloth, 8);
			recipe.AddIngredient(ItemID.AshBlock, 20);
			recipe.AddIngredient(ItemID.Obsidian, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}