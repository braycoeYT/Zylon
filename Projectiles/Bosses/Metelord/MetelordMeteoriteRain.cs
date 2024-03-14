using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordMeteoriteRain : ModProjectile
	{
        public override void SetStaticDefaults() { //Unused ver of proj?
            // DisplayName.SetDefault("Fallen Meteorite");
        }
        public override void SetDefaults() {
			Projectile.width = 52;
			Projectile.height = 52;
			//Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 200;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
			Projectile.friendly = false;
			Projectile.scale = 1.5f;
		}
		int Timer;
        public override void AI() {
			if (Projectile.timeLeft > 28) Projectile.alpha -= 15;
			Timer++;
			Projectile.rotation += 0.05f;
			if (Timer > 7) Projectile.hostile = true;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Meteorite);
			dust.scale = 1.5f;
			SoundEngine.PlaySound(SoundID.NPCDeath3);
		}
	}   
}