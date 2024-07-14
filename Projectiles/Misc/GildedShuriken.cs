using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Misc
{
	public class GildedShuriken : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ball of Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			AIType = ProjectileID.Shuriken;
			Projectile.DamageType = DamageClass.Ranged;
		}
		float chance = 2f;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (chance > 0f) Projectile.penetrate++;
			chance -= 1f;
			Projectile.damage = (int)(Projectile.damage*0.75f);
			Projectile.velocity *= -1f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (chance > 0f) {
				chance -= 0.5f;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				return false;
			}
            return true;
        }
		int Timer;
        public override void AI() {
			Timer++;
            if (Timer % 4 == 0) Projectile.velocity.Y += 1f;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}