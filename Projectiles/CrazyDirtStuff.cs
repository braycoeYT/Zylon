using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class CrazyDirtStuff : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("thee strongest dirt ball");
        }
		public override void SetDefaults()
		{
			projectile.width = 25;
			projectile.height = 25;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 15;
			projectile.melee = true;
			projectile.damage = 8;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
		}
	}   
}