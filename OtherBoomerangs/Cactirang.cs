using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Cactirang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactirang");
        }
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 7;
			projectile.melee = true;
			projectile.timeLeft = 330;
			projectile.ignoreWater = true;
		}
	}   
}