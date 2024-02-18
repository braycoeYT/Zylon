using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class TempleEqualizer : ModItem
	{

		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 7, 82);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.damage = 52;
			Item.width = 54;
			Item.height = 34;
			Item.knockBack = 1f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Yellow;
		}
		int shootCount;
		Vector2 origVelocity;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			origVelocity = Vector2.Normalize(velocity)*Main.rand.NextFloat(8f, 13f);
			float numberProjectiles = 4 + Main.rand.Next(3);
			if (shootCount % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Item91, player.Center);

				numberProjectiles = 8;
				float rotation = MathHelper.ToRadians(15);
				position += Vector2.Normalize(velocity) * 70f;

				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .6f;
					Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<Projectiles.Guns.TempleEqualizerProj>(), damage, knockback, player.whoAmI);
				}
            }
			else {
				SoundEngine.PlaySound(SoundID.Item36, player.Center);
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
					Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
			}
			return false;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-16, 0);
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BambooSharpshooter>());
			recipe.AddIngredient(ItemID.LunarTabletFragment, 17);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}