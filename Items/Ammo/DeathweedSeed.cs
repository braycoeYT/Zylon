using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class DeathweedSeed : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("For use with blowpipes\nGrows a deathweed flower on impact\nThe closer an enemy is to death, the more damage it deals");
        }
		public override void SetDefaults() {
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.DeathweedSeed>();
			Item.ammo = AmmoID.Dart;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.DeathweedSeeds);
			recipe.Register();
		}
	}
}