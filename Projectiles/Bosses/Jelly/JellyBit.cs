using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyBit : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Jelly Bit");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 240;
		}
		public override void AI() {
			int frameSpeed = 3;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}