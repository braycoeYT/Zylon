using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordMeteoriteAttack2 : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Swarm Meteorite");
        }
        public override void SetDefaults() {
			Projectile.width = 52;
			Projectile.height = 52;
			//Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
			Projectile.friendly = false;
			Projectile.scale = 1.5f;
			distSpeed = Projectile.ai[1];
		}
		Vector2 spawn;
		int Timer;
		float dist = 600;
		float distSpeed;
        public override void AI() {
			Projectile.velocity = new Vector2();
			if (Projectile.timeLeft > 28) Projectile.alpha -= 15;
			if (Timer == 0) spawn = Projectile.Center;
			Timer++;
			dist -= distSpeed;
			distSpeed += 0.03f;
			Projectile.rotation += 0.05f;
			Projectile.Center = spawn - new Vector2(0, dist).RotatedBy(Projectile.ai[0]);//*30f);//MathHelper.ToRadians((Timer*0*Projectile.ai[1])+Projectile.ai[0]*30f));//((float)Math.Pow(Timer*2, 1.1f))+Projectile.ai[0]*45));
			if (Timer > 7) Projectile.hostile = true;
			if (dist < 1) Projectile.Kill();
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 14; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Meteorite);
				dust.scale = 1.5f;
			}
			SoundEngine.PlaySound(SoundID.NPCDeath3);
		}
	}   
}