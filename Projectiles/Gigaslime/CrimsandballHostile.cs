using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Gigaslime
{
	public class CrimsandballHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Crimsand Ball");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}