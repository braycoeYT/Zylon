using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Discus
{
	public class RedOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Orb");
        }
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			aiType = -1;
		}
		public float Timer
		{
	        get => projectile.ai[0];
	        set => projectile.ai[0] = value;
        }
		public override void AI()
		{
			Timer++;
			if (Timer % 41 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("RedOrbShard"), (int)(projectile.damage / 1.3f), 2, Main.myPlayer);
			}
			projectile.rotation += 10;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 226);
				dust.noGravity = true;
				dust.scale = 0.7f;
			}
		}
	}   
}