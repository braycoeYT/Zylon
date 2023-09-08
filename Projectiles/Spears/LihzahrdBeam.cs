using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Projectiles.Spears
{
	public class LihzahrdBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lihzahrd Beam");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 25;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 169;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}