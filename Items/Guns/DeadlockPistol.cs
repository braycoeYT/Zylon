using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class DeadlockPistol : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Deadlock Pistol");
			// Tooltip.SetDefault("Fires a spread of bullets");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1, 75, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 34;
			Item.useTime = 34;
			Item.damage = 13;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 0.2f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 7.2f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(9));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddIngredient(ItemID.WormTooth, 3);
			recipe.AddRecipeGroup("Zylon:AnyGem", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FlintlockPistol);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodySpiderLeg>(), 3);
			recipe.AddRecipeGroup("Zylon:AnyGem", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}