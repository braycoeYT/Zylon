using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class Sightseer : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.damage = 58;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.LightPurple;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 2 == 0) Projectile.NewProjectile(source, player.Center - new Vector2(0, 16), velocity.RotatedBy(MathHelper.ToRadians(-5)), ModContent.ProjectileType<Projectiles.CursedFlamesMelee>(), Item.damage, Item.knockBack / 2, Main.myPlayer, 1f);
            else Projectile.NewProjectile(source, player.Center + new Vector2(0, 16), velocity.RotatedBy(MathHelper.ToRadians(5)), ModContent.ProjectileType<Projectiles.EyeLaserFriendly>(), Item.damage, Item.knockBack / 2, Main.myPlayer, 1f);
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(ItemID.SoulofSight, 9);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}