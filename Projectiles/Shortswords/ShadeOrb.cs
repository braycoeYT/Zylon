using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Shortswords
{
	public class ShadeOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shade Orb");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 120;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
		}
		public override void PostAI() {
			if (Projectile.timeLeft < 18) Projectile.alpha += 15;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.BlackDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				int dustType = DustID.Blood;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}