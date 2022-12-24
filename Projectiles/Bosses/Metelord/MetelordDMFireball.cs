using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordDMFireball : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Giga Fire");
        }
        public override void SetDefaults() {
			Projectile.width = 58;
			Projectile.height = 58;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
		}
        public override void AI() {
			if (Projectile.alpha < 0) Projectile.alpha = 0;
            if (Projectile.timeLeft > 30) Projectile.alpha -= 17;
			else Projectile.alpha += 17;
			Projectile.hostile = Projectile.alpha <= 150; //I'm a nice guy, again.
			Lighting.AddLight(Projectile.Center, 0.6f, 0f, 0f);
			Projectile.rotation += 0.08f;
			Projectile.velocity *= 0.994f;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 8));
		}
    }   
}