using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Spears
{
	public class TopazPikeProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.TopazBolt);
			AIType = ProjectileID.TopazBolt;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 25;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}