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
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Meteor Herder");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.2f;
			Projectile.alpha = 255;
		}
<<<<<<< HEAD
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
=======
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
>>>>>>> ProjectClash
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(2, 5));
		}
		public override void AI() {
			Projectile.alpha -= 15;
			for (int i = 0; i < 2; i++) {
				int dustType = DustID.MeteorHead;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Projectile.tileCollide = Main.MouseWorld.Y < Projectile.Center.Y;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}