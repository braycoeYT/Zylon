using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.ToolsofContagionex
{
	public class ContagionexSnakeTrailGood : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagionex's Snake Trail");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 0;
			projectile.height = 0;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 200;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.2f;
			projectile.damage = 0;
		}
		int Timer;
		Vector2 targetPos;
		public override void AI() {
			Timer++;
			projectile.velocity.X = 0;
			projectile.velocity.Y = 0;
			if (Timer > 100)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 20, 0, 0, mod.ProjectileType("ContagionexSnakeTrail"), 45, 0, Main.myPlayer);
				projectile.timeLeft = 0;
			}
		}
	}   
}