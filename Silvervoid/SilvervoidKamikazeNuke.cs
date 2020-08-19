using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Silvervoid
{
	public class SilvervoidKamikazeNuke : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silvervoid Nuke");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 160;
			projectile.height = 160;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}