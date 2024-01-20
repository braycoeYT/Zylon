using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class AdeniteShrapnel : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = -1;
			Projectile.frame = Main.rand.Next(4);
			Projectile.penetrate = 5;
			Projectile.aiStyle = -1;
			Projectile.scale = 0.5f;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void AI() {
            Projectile.rotation += 0.05f;
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.AdeniteDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}