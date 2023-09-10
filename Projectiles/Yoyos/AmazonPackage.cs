using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class AmazonPackage : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Package");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 28;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			//Projectile.position.Y -= 12;
		}
	}   
}