using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Accessories
{
	public class MetecoreFireball : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metefireball");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			AIType = ProjectileID.BallofFire;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.alpha = 0;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.penetrate = 1;
			Projectile.usesIDStaticNPCImmunity = true;
			Projectile.idStaticNPCHitCooldown = 30; 
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}