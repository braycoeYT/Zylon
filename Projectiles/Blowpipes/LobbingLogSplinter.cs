using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Blowpipes
{
	public class LobbingLogSplinter : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Splinter");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}