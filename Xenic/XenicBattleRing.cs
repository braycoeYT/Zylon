using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Xenic
{
	public class XenicBattleRing : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenic Battle Ring");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 2400;
			projectile.height = 2400;
			projectile.aiStyle = 0;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.timeLeft = 2;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 1f;
			projectile.damage = 0;
		}
	}   
}