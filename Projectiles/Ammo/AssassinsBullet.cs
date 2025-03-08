using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class AssassinsBullet : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
			Projectile.alpha = 400;
		}
		bool init;
        public override void AI() {
			if (!init) {
				if (Main.player[Projectile.owner].velocity.Length() < 0.01f) Projectile.damage = (int)(Projectile.damage*1.25f);
				init = true;
			}
			Projectile.velocity *= 1.03f;
			Projectile.alpha -= 18;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}