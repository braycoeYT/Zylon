using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Blowpipes
{
	public class MeteorLauncherProjFire : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ball of Fire");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			AIType = ProjectileID.BallofFire;
			Projectile.DamageType = DamageClass.Melee;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 8));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 8));
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}