using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Shadow
{
	public class OmegaShadebloodOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omega Shadeblood Orb");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.width = 96;
			projectile.height = 96;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 1200;
			aiType = -1;
		}
		public float Timer
		{
	        get => projectile.ai[0];
	        set => projectile.ai[0] = value;
        }
		int rand = Main.rand.Next(60, 261);
		public override void AI()
		{
			Timer++;
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
			if (Timer % rand == 0)
			{
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
			}
			for (int i = 0; i < 10; i++)
			{
				int dustType = 90;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}