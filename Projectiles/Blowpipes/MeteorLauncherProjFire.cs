using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Blowpipes
{
	public class MeteorLauncherProjFire : ModProjectile
	{
        public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Ball of Fire");
=======
			// DisplayName.SetDefault("Ball of Fire");
>>>>>>> ProjectClash
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			AIType = ProjectileID.BallofFire;
			Projectile.DamageType = DamageClass.Melee;
		}
<<<<<<< HEAD
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 8));
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
=======
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 8));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
>>>>>>> ProjectClash
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 8));
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}