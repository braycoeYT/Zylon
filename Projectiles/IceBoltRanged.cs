using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class IceBoltRanged : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ice Bolt");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.IceBolt);
			AIType = ProjectileID.IceBolt;
			Projectile.DamageType = DamageClass.Ranged;
			if (Projectile.ai[0] == 1f)
				Projectile.DamageType = DamageClass.Melee;
			Projectile.ai[0] = 0f;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}