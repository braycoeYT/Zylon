using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class SnowfallProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Snowfall");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.2f;
			Projectile.alpha = 255;
		}
		public override void AI() {
			Projectile.alpha -= 15;
			for (int i = 0; i < 2; i++) {
				int dustType = DustID.Ice;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Projectile.tileCollide = Main.MouseWorld.Y < Projectile.Center.Y;
		}
		float ProjectileRotation = Main.rand.NextFloat(0, 91);
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}