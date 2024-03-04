using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bows
{
	public class TrailMeteorite : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Meteor Trailer");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.alpha = 60*((int)Projectile.ai[0]+1);
			Projectile.tileCollide = false;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		float newRot;
		public override void PostAI() {
			Projectile.alpha -= 1;
			newRot += 0.1f;
			if (Projectile.alpha < 30) {
				Projectile.tileCollide = true;
				for (int i = 0; i < 2; i++) {
					int dustType = DustID.MeteorHead;
					int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
				}
			}
			Projectile.rotation = newRot;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}