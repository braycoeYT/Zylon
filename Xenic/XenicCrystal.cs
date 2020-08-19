using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Xenic
{
	public class XenicCrystal : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenic Crystal");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
	}   
}