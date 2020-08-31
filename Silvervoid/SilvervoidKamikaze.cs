using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Silvervoid
{
	public class SilvervoidKamikaze : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silvervoid Kamikaze");
        }
		public override void SetDefaults()
		{
			aiType = 1;
			projectile.width = 48;
			projectile.height = 48;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
		}
		int Timer;
		public override void AI()
		{
			projectile.rotation += 0.08f;
			if (Timer < 180)
			{
				if (Timer % 30 > 15)
				{
					//ojectile.co
				}
			}
			else
			{

			}
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}