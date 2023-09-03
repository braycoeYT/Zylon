using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class VenomousPills : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Grants immunity to acid venom");
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Pink;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[BuffID.Venom] = true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ModContent.ItemType<Materials.Oozeberry>(), 15);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}