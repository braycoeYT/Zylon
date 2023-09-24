using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class DreadclawtilusProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 30;
			Projectile.friendly = true;
		}
        public override void AI() {
            if (Projectile.timeLeft < 6) Projectile.alpha += 51;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }   
}