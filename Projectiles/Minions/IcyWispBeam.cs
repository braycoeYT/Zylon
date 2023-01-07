using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Minions
{
	public class IcyWispBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Icy Beam");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bullet);
			AIType = ProjectileID.Bullet;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.light = 0.2f;
			Projectile.tileCollide = false;
		}
		int Timer;
		public override void PostAI() {
			Timer++;
			if (Timer > 29) Projectile.tileCollide = true;
			Projectile.velocity *= 1.012f;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}