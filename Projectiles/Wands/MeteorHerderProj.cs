using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Wands
{
	public class MeteorHerderProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.2f;
			Projectile.alpha = 255;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		int Timer;
		public override void AI() {
			if (Projectile.ai[1] == 0) {
				Timer = (int)-Projectile.ai[0];
				Projectile.ai[1] = 1f;
            }
			Timer++;
			if (Timer >= 0 && Projectile.ai[1] == 1) {
				Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.MouseWorld) * (float)(-15f);
				Projectile.timeLeft = 90;
				Projectile.friendly = true;
				Projectile.ai[1] = 2;
            }
		}
        public override void PostAI() {
            for (int i = 0; i < 2; i++) {
				int dustType = DustID.MeteorHead;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Projectile.alpha -= 15;
			Projectile.rotation += 0.06f*((255-Projectile.alpha)/255);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}