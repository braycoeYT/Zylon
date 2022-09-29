using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles
{
	public class EyeLaserFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye Laser");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.GreenLaser);
			AIType = ProjectileID.GreenLaser;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.hostile = false;
			if (Projectile.ai[0] == 1f)
				Projectile.DamageType = DamageClass.Ranged;
			Projectile.ai[0] = 0f;
		}
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}