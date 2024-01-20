using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class ShrapnelGun : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Uses shrapnel as ammo\n90% chance not to consume ammo\nFires multiple small bits of shrapnel");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 2);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 52;
			Item.useTime = 52;
			Item.damage = 11;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 1.8f;
			Item.shootSpeed = 17f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
			Item.crit = 15;
			Item.shoot = ModContent.ProjectileType<Projectiles.Ammo.AdeniteShrapnel>();
			Item.useAmmo = ModContent.ItemType<Ammo.AdeniteShrapnel>();
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextBool(10);
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 4;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(6)) * Main.rand.NextFloat(0.75f, 1.25f);
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
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 35);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}