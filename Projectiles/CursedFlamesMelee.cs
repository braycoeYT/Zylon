using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class CursedFlamesMelee : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cursed Flames");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.CursedFlameFriendly);
			AIType = ProjectileID.CursedFlameFriendly;
			Projectile.DamageType = DamageClass.Melee;
			if (Projectile.ai[0] == 1)
				Projectile.DamageType = DamageClass.Ranged;
			Projectile.ai[0] = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}