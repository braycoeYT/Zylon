using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class Cryostring : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 5, 12);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.damage = 9;
			Item.width = 18;
			Item.height = 30;
			Item.knockBack = 0.5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 6.6f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (Main.rand.NextBool(5)) for (int i = 0; i < Main.rand.Next(3, 5); i++)
				Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(20))*1.25f, ModContent.ProjectileType<Projectiles.Bows.CryostringProj>(), damage/2, 1f, Main.myPlayer, Main.rand.Next(3));
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}