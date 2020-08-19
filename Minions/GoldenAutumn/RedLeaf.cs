using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions.GoldenAutumn
{
	public class RedLeaf : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Red Leaf");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		int swing;
		int swingDir = Main.rand.Next(0, 2);
		int Timer;
		bool start;
		public override void AI()
		{
			if (start)
			{

			}
			Timer++;
			if (Timer % 10 == 0)
			{
				swing++;
				if (swingDir % 2 == 0)
				projectile.velocity.X += 2;
				else
				projectile.velocity.X -= 2;
				if (swing > 4)
				{
					swing = 0;
					swingDir++;
				}
			}
			projectile.rotation = 0;
			projectile.velocity.Y = (float)(projectile.velocity.Y * 0.9);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 105);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
	}   
}