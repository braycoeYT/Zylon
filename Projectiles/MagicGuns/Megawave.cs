using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.MagicGuns
{
	public class Megawave : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Megawave");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 12;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 360;
			Projectile.ignoreWater = true;
			Projectile.light = 0.3f;
			AIType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			grow += 0.5f;
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				grow += 0.5f;
			}
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
		float grow;
		public override void AI() {
			if (grow > 0) {
				grow -= 0.01f;
				Projectile.scale += 0.01f;
			}
			Projectile.width = (int)(20 * Projectile.scale);
			Projectile.height = (int)(20 * Projectile.scale);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}