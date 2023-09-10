using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordMeteoriteAttack : ModProjectile
	{
        public override void SetStaticDefaults() { //Unused ver of proj?
            // DisplayName.SetDefault("Swarm Meteorite");
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
		Vector2 spawn;
		int Timer;
		int dist = 800;
        public override void AI() {
			Projectile.velocity = new Vector2();
			if (Projectile.timeLeft > 28) Projectile.alpha -= 15;
			if (Timer == 0) spawn = Projectile.Center;
			Timer++;
			dist -= 4;
			Projectile.rotation += 0.05f;
			Projectile.Center = spawn - new Vector2(0, dist).RotatedBy(MathHelper.ToRadians((Timer*0*Projectile.ai[1])+Projectile.ai[0]*30f));//((float)Math.Pow(Timer*2, 1.1f))+Projectile.ai[0]*45));
			if (Timer > 7) Projectile.hostile = true;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Meteorite);
			dust.scale = 1.5f;
			SoundEngine.PlaySound(SoundID.NPCDeath3);
		}
	}   
}