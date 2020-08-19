using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Dirtball
{
	public class DirtBall : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Ball");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
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
		int dirtRan = Main.rand.Next(0, 120);
		int Timer;
		public override void AI()
		{
			Timer++;
			if (++projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
			if (Main.expertMode && Timer % 120 == dirtRan)
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -6, mod.ProjectileType("DirtTile"), 9, 0, Main.myPlayer);
			if (Main.expertMode && Timer % 120 == dirtRan)
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("DirtTile"), 9, 0, Main.myPlayer);
		}
	}   
}