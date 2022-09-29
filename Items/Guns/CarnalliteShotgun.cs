using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class CarnalliteShotgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a spread of leaves with every shot");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 58;
			Item.useTime = 58;
			Item.damage = 45;
			Item.width = 40;
			Item.height = 16;
			Item.knockBack = 3f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Green;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for (int i = 0; i < 4; i++) {
				Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.8f, 1.2f), velocity.Y * Main.rand.NextFloat(0.8f, 1.2f)).RotatedByRandom(MathHelper.ToRadians(14));
				Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<Projectiles.Leaf>(), (int)(damage * 0.35f), knockback * 0.5f, player.whoAmI, 1f);
			}
			return true;
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
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}