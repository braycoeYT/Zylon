using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Dirtball
{
	public class CrazyDirtStuff : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("thee strongest dirt ball");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}