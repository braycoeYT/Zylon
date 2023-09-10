using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class HeartbreakerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Life Crystal");
			Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 5;
			Projectile.ignoreWater = true;
		}
		public override void AI() {
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HeartCrystal);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HeartCrystal);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}