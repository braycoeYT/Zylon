using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordFireDrop1 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fallen Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.GreekFire1);
		}
        public override void PostAI() {
            Projectile.rotation = 0f;
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				//dust.noGravity = true;
				dust.scale = 0.5f;
			}
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 5), false);
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}