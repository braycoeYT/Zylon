using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Mineral
{
	public class ZMEGhost : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 380;
			projectile.height = 518;
			projectile.aiStyle = 0;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0f;
			projectile.damage = 0;
			projectile.alpha = 0;
		}
		public override void AI()
		{
			projectile.alpha += 25;
			if (projectile.alpha > 254)
				projectile.timeLeft = 0;
		}
	}   
}