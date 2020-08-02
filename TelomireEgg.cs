using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class TelomireEgg : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Egg");
        }
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = Main.rand.Next(300, 501);
			projectile.penetrate = -1;
			aiType = -1;
		}
		public float Timer
		{
	        get => projectile.ai[0];
	        set => projectile.ai[0] = value;
        }
		int rand = Main.rand.Next(20, 181);
		public override void AI()
		{
			Timer++;
			if (Timer % rand == 0)
			{
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
			}
			if (Timer % 26 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EggResidue"), projectile.damage + 30, 2, Main.myPlayer);
			}
			projectile.rotation += 10;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 153);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
	}   
}