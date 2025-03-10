using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class OozingBullet : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Oozing Bullet");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
			Projectile.alpha = 400;
		}
        public override void AI() {
            Projectile.alpha -= 18;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<OozeCloud>(), Projectile.damage/4, 0f, Projectile.owner);
		}
	}   
}