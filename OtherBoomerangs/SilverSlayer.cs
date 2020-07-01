using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class SilverSlayer : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silver Slayer");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 45;
			projectile.height = 45;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 330;
			projectile.ignoreWater = true;
		}
	}   
}