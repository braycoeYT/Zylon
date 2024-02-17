using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Wands
{
	public class DirtBallScepter2 : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 360;
			Projectile.DamageType = DamageClass.Magic;
		}
		bool hitGround;
        public override void AI() {
			if (!hitGround && Projectile.timeLeft % 3 == 0) Projectile.velocity.Y += 1;
			if (Projectile.velocity.Y > 10) Projectile.velocity.Y = 10;
            Projectile.friendly = hitGround;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			hitGround = true;
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			Projectile.tileCollide = false;
			Projectile.velocity = Vector2.Zero;
            return false;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}