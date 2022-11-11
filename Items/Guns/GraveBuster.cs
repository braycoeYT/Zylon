using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class GraveBuster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Grave robbing for morons'\nHitting enemies will give you the 'Gravely Powers' buff, which increases your life regen");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 29;
			Item.useTime = 29;
			Item.damage = 13;
			Item.width = 22;
			Item.height = 54;
			Item.knockBack = 1.8f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i < 4; i++)
            {
				Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-12, 12))), ModContent.ProjectileType<Projectiles.Guns.SpiritBullet>(), (int)(damage * 0.58f), knockback, player.whoAmI, 0f, 0f);
			}
			Gore.NewGore(source, position, (-velocity * 0.23f) + new Vector2(0f, -4f), ModContent.GoreType<Gores.Effects.Specialized.GraveBusterBulletGore>());


			return false;
        }

        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Recipe.Condition.InGraveyardBiome);
			recipe.Register();
		}
	}
}