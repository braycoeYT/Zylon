using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class CarnalliteBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Every third shot releases a leaf with each arrow");
		}
		public override void SetDefaults()  {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.damage = 28;
			Item.width = 42;
			Item.height = 42;
			Item.knockBack = 1f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 7.2f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			if (shootCount % 3 == 0)
				Projectile.NewProjectile(source, player.Center, velocity * 1.5f, ModContent.ProjectileType<Projectiles.Leaf>(), damage, knockback, Main.myPlayer, 1f);
			return true;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ProjectileID.WoodenArrowFriendly) {
				type = mod.ProjectileType("GreenCarnalliteArrow");
			}
			return true;
		}*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}