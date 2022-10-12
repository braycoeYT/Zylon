using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Projectiles.Spears
{
	public class KivasanaProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kivasana");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 9999;
		}
		public override void AI() {
			Projectile.velocity *= 1.025f;
			for (int i = 0; i < 2; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 15; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}