using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class SparklyGelFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sparkly Gel");
        }
		public override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 9999;
			Projectile.scale = 0.5f;
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
		int bounce = 3;
        public override bool OnTileCollide(Vector2 oldVelocity) {
			bounce--;
			if (bounce <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.SplashWeak, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
		float floa;
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkSlime);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			floa += 0.1f;
			Projectile.rotation = floa;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 12; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkSlime);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}