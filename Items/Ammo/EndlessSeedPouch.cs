using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ammo
{
	public class EndlessSeedPouch : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bottomless Sack of Seeds");
			// Tooltip.SetDefault("For use with blowpipes");
        }
		public override void SetDefaults() {
			Item.damage = 6; //3
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 32;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 0f; //0
			Item.value = Item.sellPrice(0, 1, 0, 0); //0
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.Seed;
			Item.shootSpeed = 0f; //0
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Seed, 3996);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}