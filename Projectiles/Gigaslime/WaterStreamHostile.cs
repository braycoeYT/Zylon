using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Gigaslime
{
	public class WaterStreamHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Stream");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WaterStream);
			AIType = ProjectileID.WaterStream;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
			Projectile.scale *= 2f;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}