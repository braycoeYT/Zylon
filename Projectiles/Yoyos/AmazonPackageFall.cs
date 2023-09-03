using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Yoyos
{
	public class AmazonPackageFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Package");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 28;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<AmazonPackage>(), Projectile.damage, 0, Projectile.owner);
		}
	}   
}