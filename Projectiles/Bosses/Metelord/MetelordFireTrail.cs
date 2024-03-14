using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordFireTrail : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flame Orb");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
			Projectile.scale = 0f;
		}
        public override void AI() {
			if (Projectile.scale < 1.5f) Projectile.scale += 0.025f;
			else Projectile.hostile = true;
            if (Projectile.timeLeft < 18)
				Projectile.alpha += 15;
			Lighting.AddLight(Projectile.Center, 0.6f, 0f, 0f);
			if (++Projectile.frameCounter >= 3) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
        }
        /*public override void PostAI() { //was gonna do this but it ate up all of the dust slots...
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				//dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}*/
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5)*60);
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}