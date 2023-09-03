using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDLaser : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Diskite Laser");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.EyeLaser);
			AIType = ProjectileID.EyeLaser;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}