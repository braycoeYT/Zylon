using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Projectiles.Misc
{
	public class MagnificentOrbProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magnificent Orb");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.2f;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer < 40) Projectile.alpha -= 15;
			else Projectile.alpha += 15;
			if (Timer >= 40 && Projectile.alpha <= 1) Projectile.active = false;
			if (Timer == 25) Projectile.velocity = new Microsoft.Xna.Framework.Vector2(0, -20).RotatedByRandom(6.28f);
			/*for (int i = 0; i < 2; i++) {
				int dustType = 1;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}*/
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}