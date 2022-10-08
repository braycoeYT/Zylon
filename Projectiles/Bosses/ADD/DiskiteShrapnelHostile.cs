using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class DiskiteShrapnelHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Diskite Shrapnel");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = -1;
			Projectile.frame = Main.rand.Next(4);
			Projectile.penetrate = -1;
			Projectile.scale = 0.5f;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 480;
		}
        public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.7f, 0.125f, 0.125f);
            Projectile.rotation += 0.05f;
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.DiskiteDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}