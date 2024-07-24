using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class BloodButler : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 3, 56, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.damage = 16;
			Item.width = 40;
			Item.height = 16;
			Item.knockBack = 4f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 8f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Orange;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(6, 0);
		}
		int shootCount = -1;
		int bulletCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			bulletCount = shootCount % 4 + 1;
			for (int i = 0; i < bulletCount; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.ToRadians((bulletCount*5/2) - (i*5)));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 15);
			recipe.AddIngredient(ItemID.Bone, 45);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}