using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class BambooSharpshooter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a spread of bullets and poisonous bamboo spikes");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 3, 23);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 34;
			Item.useTime = 34;
			Item.damage = 17;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 5.8f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 6.15f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Green;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
				Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<Projectiles.Guns.BambooSpike>(), damage, knockback, player.whoAmI);
			}
			numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(ItemID.BambooBlock, 30);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale");
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}