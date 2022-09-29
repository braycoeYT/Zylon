using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyLaserFast : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Blast");
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(83);
			Projectile.aiStyle = 1;
			AIType = ProjectileID.GreenLaser;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 480;
		}
		bool bool1;
		public override void AI() {
			if (!bool1) {
				Projectile.position += Projectile.velocity*250f;
				bool1 = true;
			}
			Projectile.velocity *= 1.006f;
		}
	}
}