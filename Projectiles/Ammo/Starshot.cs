using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class Starshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Starshot");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.timeLeft = 400;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage /= 2;
			if (Projectile.damage < 1) Projectile.damage = 1;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}