using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Misc
{
	public class CursedFlamethrower : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flamelicker");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 45;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.alpha = 255;
			Projectile.light = 0.25f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(8, 17), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(8, 17), false);
		}
        public override void PostAI() {
            for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 3f;
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}