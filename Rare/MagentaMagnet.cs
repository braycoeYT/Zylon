using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Rare
{
	public class MagentaMagnet : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magenta Magnet");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		int rand = Main.rand.Next(47, 183);
		public float Timer
		{
	        get => projectile.ai[1];
	        set => projectile.ai[1] = value;
        }
		public override void AI()
		{
			Timer++;
			if (Timer % rand == 0)
			{
				Projectile.NewProjectile(projectile.Center, projectile.DirectionTo(Main.MouseWorld) * projectile.velocity.Y, 121, projectile.damage, projectile.knockBack, Main.myPlayer);
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 119);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
	}   
}