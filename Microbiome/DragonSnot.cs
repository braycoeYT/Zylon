using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Microbiome
{
	public class DragonSnot : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Snot");
        }
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = Main.rand.Next(140, 311);
			projectile.penetrate = -1;
			aiType = -1;
		}
		public float Timer
		{
	        get => projectile.ai[0];
	        set => projectile.ai[0] = value;
        }
		int rand = Main.rand.Next(40, 156);
		public override void AI()
		{
			Timer++;
			if (Timer % rand == 0)
			{
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
			}
			for (int i = 0; i < 4; i++)
			{
				int dustType = 256;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			projectile.rotation += 9;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		    target.AddBuff(mod.BuffType("Sick"), 300, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("Sick"), 300, false);
		}
	}   
}