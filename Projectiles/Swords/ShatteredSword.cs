using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class ShatteredSword : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Shattered Sword");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.TerraBeam);
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 40;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.light = 0.5f;
			Projectile.tileCollide = false;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
				dust.scale = 1f;
            }
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}