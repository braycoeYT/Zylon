using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Microbiome
{
	public class MorbusPetal : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Morbus Petal");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 1200;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.damage = 101;
		}
	}   
}