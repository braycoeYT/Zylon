using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class HostileErrorShot : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("the Unknown");
        }
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.EyeLaser);
			projectile.width = 20;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			aiType = ProjectileID.EyeLaser;
		}
	}   
}