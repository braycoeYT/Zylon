using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Blowpipes
{
	public class Slimeball : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimeball");
			Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 9999;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
		    target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void AI() {
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}