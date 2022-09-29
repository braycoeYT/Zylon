using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class CrimsonSeed : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nCan pierce up to four times, heavily increasing critical strike chance each time");
        }
		public override void SetDefaults() {
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.CrimsonSeed>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.CrimsonSeeds);
			recipe.Register();
		}
	}
}