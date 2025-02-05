using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class PizazzCannon : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 12);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.damage = 70;
			Item.width = 42;
			Item.height = 30;
			Item.knockBack = 3f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Lime;
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int shootCount = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = 0;
			shootCount++;
            if (shootCount % 3 == 2) Item.reuseDelay = 30;
            if (shootCount % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Item67.WithPitchOffset(Main.rand.NextFloat(0.5f, 1f)), player.Center);
				//Projectile.NewProjectile(source, position, velocity*0.9f, type, (int)(damage*0.13f), knockback/4f, Main.myPlayer);
				//if (shootCount % 18 == 16) Item.reuseDelay = 40;
				for (int i = 0; i < 10; i++) Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(30))*Main.rand.NextFloat(1.25f, 1.75f), ModContent.ProjectileType<Projectiles.Guns.PizazzCannonProj>(), damage, knockback, Main.myPlayer);
				Projectile.NewProjectile(source, position, velocity, ProjectileID.ConfettiGun, 0, 0f, Main.myPlayer);
				Item.reuseDelay = 0;
				return false;
			}
			//if (shootCount % 6 == 0) SoundEngine.PlaySound(SoundID.Item41, player.Center);
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ConfettiGun);
			recipe.AddIngredient(ItemID.DiscoBall, 10);
			recipe.AddIngredient(ItemID.RainbowBrick, 75);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}