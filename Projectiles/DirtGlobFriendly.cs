using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class DirtGlobFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Glob");
			Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			switch (Projectile.ai[0]) {
				case 0:
					Projectile.DamageType = DamageClass.Melee;
					return;
				case 1:
					Projectile.DamageType = DamageClass.Ranged;
					return;
				case 2:
					Projectile.DamageType = DamageClass.Magic;
					return;
				case 3:
					Projectile.DamageType = DamageClass.SummonMeleeSpeed;
					return;
			}
			Projectile.ai[0] = 0;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}