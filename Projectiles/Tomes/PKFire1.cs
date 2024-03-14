using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class PKFire1 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Volcanic Flame");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 30;
			Projectile.ignoreWater = true;
			AIType = ProjectileID.Bullet;
			Projectile.DamageType = DamageClass.Magic;
		}
		int child = ModContent.ProjectileType<PKFire2>();
		int offset = 0;
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 9), false);
			child = ModContent.ProjectileType<PKFireWall>();
			offset = 30;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 9), false);
			child = ModContent.ProjectileType<PKFireWall>();
			offset = 30;
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
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Microsoft.Xna.Framework.Vector2(0, offset), new Microsoft.Xna.Framework.Vector2(0, 12), child, Projectile.damage, Projectile.knockBack, Projectile.owner);
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