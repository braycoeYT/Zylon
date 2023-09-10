using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Materials
{
	public class MetallicBell : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Not to be confused with the Bell, Fairy Bell, Reindeer Bells, Eerie Bell, or Eldritch Bell");
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Bell);
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 0, 12, 0);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item35.WithPitchOffset(4f);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}