using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Mecharang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mecharang");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 630;
			projectile.ignoreWater = true;
		}
	}   
}