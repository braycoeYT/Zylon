using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class CarnalliteWandProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Leaf");
			Main.projFrames[Projectile.type] = 5;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		int Timer;
		bool init;
        public override void AI() {
			if (!init) {
				Timer = (int)Projectile.ai[0];
				init = true;
            }
			Timer++;
			//if (Timer < 0) return;

			if (Timer > 0) Projectile.alpha -= 8;

			if (Timer <= 32) {
				Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.MouseWorld)*-15f;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

				if (Timer < 32) Projectile.velocity = Vector2.Zero; //don't move yet
				else Projectile.friendly = true; //GO!!
            }
			if (Timer > 40) Projectile.tileCollide = true;

			//Animate
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