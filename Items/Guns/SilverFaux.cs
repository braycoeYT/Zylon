using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class SilverFaux : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Silver Faux");
			Tooltip.SetDefault("'Hot to the touch'\nShoots a flaming shard that blasts into shrapnel");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5, 50, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.damage = 26;
			Item.width = 42;
			Item.height = 30;
			Item.knockBack = 2.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-2, 2))), ModContent.ProjectileType<Projectiles.Guns.SilverFauxBlast>(), damage * 3, knockback, player.whoAmI, 0f, 0f);

			Gore.NewGore(source, position, (-velocity * 0.23f) + new Vector2(0f, -4f), ModContent.GoreType<Gores.Effects.Specialized.SilverFauxBulletGore>());
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddRecipeGroup("Zylon:AnyGem", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}