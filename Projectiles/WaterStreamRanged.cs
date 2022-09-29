using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class WaterStreamRanged : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Stream");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WaterStream);
			AIType = ProjectileID.WaterStream;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 99999;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}