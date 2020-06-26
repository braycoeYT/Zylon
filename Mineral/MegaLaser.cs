using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Mineral
{
	public class MegaLaser : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mega Laser");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.2f;
			if (Main.expertMode)
				projectile.damage = 140;
			else
				projectile.damage = 180;
		}
	}   
}