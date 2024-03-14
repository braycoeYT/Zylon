using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class BoneArrowProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bone);
			AIType = ProjectileID.Bone;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 3;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}