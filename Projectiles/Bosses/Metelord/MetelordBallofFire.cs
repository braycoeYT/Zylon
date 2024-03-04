using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordBallofFire : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ball of Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			AIType = ProjectileID.BallofFire;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.timeLeft = 120;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 6));
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 5 == 0 && Projectile.velocity.Y < 0) Projectile.velocity.Y += 1;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}