using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Wands
{
	public class TreeTruncheonProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.frame = Main.rand.Next(6);
		}
        public override void AI() {
			Projectile.alpha -= 27;
			Projectile.velocity.Y += 0.5f;
			Projectile.velocity.X *= 0.97f;
			if (Projectile.velocity.Y > 12) Projectile.velocity.Y = 12;

			Projectile.rotation += 0.05f*Projectile.velocity.X+0.08f;

			//Passive dust spawn
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}