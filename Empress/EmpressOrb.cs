using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Empress
{
	public class EmpressOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empress Orb");
			Main.projFrames[projectile.type] = 1;
        }
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
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
			if (Timer % rand == 0)
			{
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
			}
			for (int i = 0; i < 10; i++)
			{
				int dustType = 183;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.6f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}