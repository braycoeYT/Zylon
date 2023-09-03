using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDLaser4 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Diskite Laser");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DeathLaser);
			AIType = ProjectileID.DeathLaser;
			Projectile.timeLeft = 360;
			Projectile.tileCollide = false;
		}
		int Timer;
		Vector2 orig;
        public override void AI() {
            Timer++;
			if (Timer < 2) {
				orig = Projectile.velocity;
				orig.Normalize();
            }
			if (Timer >= 120 && Timer < 136)
				Projectile.velocity -= orig;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}