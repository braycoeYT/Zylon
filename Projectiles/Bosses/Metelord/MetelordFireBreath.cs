using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordFireBreath : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Breath");
			Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 58;
			Projectile.height = 58;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 120+(int)Projectile.ai[0];
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
		}
        public override void AI() {
            if (Projectile.timeLeft < 20) Projectile.alpha += 17;
			else Projectile.alpha -= 17;
			if (Projectile.alpha > 150) Projectile.hostile = false; //I'm a nice guy.
			else Projectile.hostile = true;
			Lighting.AddLight(Projectile.Center, 0.6f, 0f, 0f);
			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 6));
		}
    }   
}