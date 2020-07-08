using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Mineral
{
	public class MineralLaserBeam : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Beam");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 14;
			projectile.height = 1560;
			projectile.aiStyle = 0;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 150;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.2f;
			projectile.damage = 200;
		}
	}   
}