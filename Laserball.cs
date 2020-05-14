using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class Laserball : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Ball");
        }
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
		}
	}   
}