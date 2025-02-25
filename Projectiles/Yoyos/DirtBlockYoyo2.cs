using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class DirtBlockYoyo2 : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
		}
        public override void AI() {
			Projectile.velocity.X = Projectile.velocity.X*0.98f;
            Projectile.velocity.Y += 0.33f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.velocity.Y -= 10f;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}