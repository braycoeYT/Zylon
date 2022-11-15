using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Snowfall : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Launches 3 snowflakes towards your cursor\n'Winter is coming...'");
		}
		public override void SetDefaults() {
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 13;
			Item.useAnimation = 39;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 0, 38);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.SnowfallProj>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 10;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

			Projectile.NewProjectile(source, position, -velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-22, 22))), type, damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}