using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Boomerangs
{
	public class FireandIce_1 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ball of Frost");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFrost);
			AIType = ProjectileID.BallofFrost;
			Projectile.DamageType = DamageClass.Melee;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(3, 8));
		}
<<<<<<< HEAD
        public override void OnHitPlayer(Player target, int damage, bool crit) {
        target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(3, 8));
=======
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(3, 8));
>>>>>>> ProjectClash
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}