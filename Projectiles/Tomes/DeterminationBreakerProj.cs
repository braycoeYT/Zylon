using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class DeterminationBreakerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Determination Breaker");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 50;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		bool stop;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (!stop) Projectile.timeLeft = 240;
            stop = true;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (!stop) Projectile.timeLeft = 240;
            stop = true;
        }
		int Timer;
        public override void AI() {
			Timer++;
			for (int i = 0; i < 2; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Bone);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (stop) {
				Projectile.velocity = new Vector2(0, 0);
				Projectile.aiStyle = -1;
				Projectile.rotation += 0.1f;
				if (Timer % 60 == 0) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8).RotatedByRandom(6.28f), ProjectileID.BookOfSkullsSkull, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}