using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Microbiome
{
	public class InfectedDartTrail : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Infected Dart");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(mod.BuffType("Sick"), 60 * Main.rand.Next(3, 7), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Sick"), 60 * Main.rand.Next(3, 7), false);
		}
		public override void AI() {
			for (int i = 0; i < 10; i++) {
				int dustType = mod.DustType("MicrobiomeDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}