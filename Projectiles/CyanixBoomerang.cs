using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class CyanixBoomerang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyanix Boomerang");
        }
		public override void SetDefaults()
		{
			projectile.width = 25;
			projectile.height = 25;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.melee = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = false;
		}
	}   
}