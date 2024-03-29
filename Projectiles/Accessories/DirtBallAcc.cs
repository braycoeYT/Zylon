using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Accessories
{
	public class DirtBallAcc : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Dirt Ball");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}