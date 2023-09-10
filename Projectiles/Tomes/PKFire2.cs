using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class PKFire2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Volcanic Flame");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6), false);
		}
<<<<<<< HEAD
		public override void OnHitPvp(Player target, int damage, bool crit) {
=======
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
>>>>>>> ProjectClash
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6), false);
		}
		public override void AI() {
			for (int i = 0; i < 4; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center.X, Projectile.Center.Y - 30, 0, 0, ModContent.ProjectileType<PKFireWall>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
			for (int i = 0; i < 4; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}