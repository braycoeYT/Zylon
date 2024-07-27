using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace Zylon.Items.Guns
{
	public class TempleEqualizer : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 7, 82);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 35;
			Item.useTime = 5;
			Item.damage = 61;
			Item.width = 80;
			Item.height = 28;
			Item.knockBack = 1f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Yellow;
			//Item.UseSound = SoundID.Item11;
			Item.reuseDelay = 15;
			Item.consumeAmmoOnFirstShotOnly = true;
		}
		int shootCount;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (shootCount % 7 != 0) velocity = velocity.RotatedBy(MathHelper.ToRadians(4f-(float)Math.Sin(Main.GameUpdateCount/5f)*8f));
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			if (shootCount % 7 == 1) {
				SoundEngine.PlaySound(SoundID.Item91, player.Center);
				Projectile.NewProjectile(source, position, velocity/2f, ModContent.ProjectileType<Projectiles.Guns.TempleEqualizerProj>(), damage, knockback, player.whoAmI);
            }
			else SoundEngine.PlaySound(SoundID.Item11, player.Center);
			return shootCount % 7 != 1;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-16, 0);
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 17);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}