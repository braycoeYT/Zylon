using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class ManaPod : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 1, 23);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.velocity.X < 0.01f && player.velocity.Y < 0.01f) player.manaRegen += 2;
			if (!player.ZoneUnderworldHeight && !player.ZoneRockLayerHeight && !player.ZoneDirtLayerHeight && Main.dayTime)
				player.statManaMax2 += 40;
			else player.statManaMax2 += 10;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Glass, 10);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}