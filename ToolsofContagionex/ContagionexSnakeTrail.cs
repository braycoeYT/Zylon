using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.ToolsofContagionex
{
	public class ContagionexSnakeTrail : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagionex's Snake Trail");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 200;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.2f;
			projectile.damage = 280;
		}
	}   
}