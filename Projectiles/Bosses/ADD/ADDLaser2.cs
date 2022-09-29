using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDLaser2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Diskite Laser");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DeathLaser);
			AIType = ProjectileID.DeathLaser;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = false;
		}
        public override void OnSpawn(IEntitySource source) {
			//SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}