using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Minions
{
	public class PossessedDiamondProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DiamondBolt);
			AIType = ProjectileID.DiamondBolt;
			Projectile.DamageType = DamageClass.Summon;
		}
		int Timer;
        public override void AI() {
            Timer++;
			Projectile.tileCollide = Timer > 30;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}