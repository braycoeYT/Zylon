using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class ElectricSpeck : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electric Speck");
        }
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.EyeLaser);
			projectile.width = 39;
			projectile.height = 39;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 1200;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.extraUpdates = 2;
			aiType = 1;
		}
		public override void AI()
		{
			for (int i = 0; i < 4; i++)
			{
				int dustType = 226;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}