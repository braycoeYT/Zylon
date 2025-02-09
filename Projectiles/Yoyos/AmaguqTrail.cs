using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class AmaguqTrail : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 30;
			Projectile.ignoreWater = true;
		}
        public override void AI() {
			Projectile.rotation +=  0.08f;
            Projectile.alpha = (int)(255f-255f*((float)Projectile.timeLeft/30f));
        }
    }   
}