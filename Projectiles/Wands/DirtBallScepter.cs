using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Wands
{
	public class DirtBallScepter : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Dirt Ball");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
		}
        public override void AI() {
            Projectile.alpha -= 15;
        }
        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}