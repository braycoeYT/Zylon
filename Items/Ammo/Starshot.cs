using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class Starshot : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("For use with blowpipes\nPierces infinitely and ignores gravity");
        }
		public override void SetDefaults() {
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 18;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = 10;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.Starshot>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.Register();
		}
	}
}