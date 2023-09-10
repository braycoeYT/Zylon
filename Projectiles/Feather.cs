using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class Feather : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Feather");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.HarpyFeather);
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Skyware);
				dust.noGravity = false;
				dust.scale = 1f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}