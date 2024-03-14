using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class KrakenBlast : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 4, 23);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 8;
			Item.damage = 21;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 4.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 6.8f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			//Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Orange;
			Item.reuseDelay = 26;
			Item.consumeAmmoOnFirstShotOnly = true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int s;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            s++;
			if (s % 3 != 0) { SoundEngine.PlaySound(SoundID.Item41, position); return true; }
			SoundEngine.PlaySound(SoundID.Item36, position);
			int numberProjectiles = 4;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(21));
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
			recipe.AddIngredient(ModContent.ItemType<DeadlockPistol>());
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 13);
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 9);
			recipe.AddIngredient(ItemID.Coral, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}