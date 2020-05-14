using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Dirtball
{
	public class DirtBall2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Ball");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			aiType = 1;
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
		public float Timer
		{
	        get => projectile.ai[1];
	        set => projectile.ai[1] = value;
        }
		public override void AI()
		{
			Timer++;
			if (Timer % 60 == 0)
			projectile.velocity.Y -= 1;
			if (++projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
		}
	}   
}