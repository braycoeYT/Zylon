using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Microbiome
{
	public class Ickyspit : ModProjectile
	{
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 12;
			projectile.height = 12;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 99999;
			projectile.ignoreWater = true;
		}
		public override void AI()
		{
			for (int i = 0; i < 2; i++)
			{
				int dustType = 48;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("Sick"), 250, false);
		}
	}   
}