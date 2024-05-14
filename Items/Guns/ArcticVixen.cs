using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class ArcticVixen : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 7, 25);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 41;
			Item.useTime = 41;
			Item.damage = 109;
			Item.width = 50;
			Item.height = 36;
			Item.knockBack = 7f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.LightRed;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount % 15 <= 3;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 15 == 0) {
				Item.damage = 109;
				Item.UseSound = SoundID.Item41;
			}
			if (shootCount % 15 == 2) {
				Item.knockBack = 1.25f;
				Item.shootSpeed = 10f;
			}
			if (shootCount % 15 == 3) {
				Item.damage = 12;
				Item.useAnimation = 6;
				Item.useTime = 6;
				Item.UseSound = SoundID.Item11;
			}
			if (shootCount % 15 == 14) {
				Item.knockBack = 7f;
				Item.useAnimation = 41;
				Item.useTime = 41;
				Item.shootSpeed = 12f;
			}
			if (shootCount % 15 > 3 || shootCount % 15 == 0) {
				Projectile.NewProjectile(source, position, velocity, ProjectileID.SnowBallFriendly, damage, knockback, Main.myPlayer);
				return false;
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Foxtrot>());
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 8);
			recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}