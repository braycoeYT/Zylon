using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordFireDrop2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fallen Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.GreekFire2);
		}
		public override void PostAI() {
            Projectile.rotation = 0f;
			if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				//dust.noGravity = true;
				dust.scale = 0.5f;
			}
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 4), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(2, 4), false);
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}