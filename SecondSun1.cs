using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class SecondSun1 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("the Second Sun");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			//projectile.penetrate = 3;
			projectile.melee = true;
			projectile.damage = 12;
			//projectile.timeLeft = 300;
			projectile.ignoreWater = false;
		}
	}   
}