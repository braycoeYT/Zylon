using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ammo
{
	public class GiantGelCluster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with flamethrowers and other gel-consuming weapons");
        }
		public override void SetDefaults() {
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 14;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 0f;
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.ammo = AmmoID.Gel;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 999);
			recipe.AddIngredient(ItemID.PinkGel, 25);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 10);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}