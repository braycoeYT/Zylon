using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class BallofFireRanged : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ball of Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			AIType = ProjectileID.BallofFire;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}