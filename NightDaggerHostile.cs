using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class NightDaggerHostile : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Dagger");
        }
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.EyeLaser);
			projectile.width = 50;
			projectile.height = 50;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			aiType = 1;
		}
	}   
}