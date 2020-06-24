using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class HostileErrorShot : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Error loading C:/Terraria/Zylon/Projectiles/HostileErrorShot");
        }
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
		}
	}   
}