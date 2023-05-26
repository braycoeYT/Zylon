using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Blowpipes
{
	public class WindpipeofthePhoenixProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Phoenix Breath");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Flames);
			AIType = ProjectileID.Flames;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11));
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11));
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}