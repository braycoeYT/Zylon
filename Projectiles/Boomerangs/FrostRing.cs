using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class FrostRing : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		Vector2 target;
		public override void AI() {
			if (Timer == 0) target = Main.MouseWorld;
			Timer++;
			Projectile.rotation += 0.13f;

			if (Timer == 25) Projectile.velocity = Projectile.Center.DirectionTo(target)*13f;

			if (Timer >= 50 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.08f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-27f*speedAcc;
			}
			else if (Timer >= 40 || (Timer > 15 && Timer < 25)) Projectile.velocity *= 0.95f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.5f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1f;
			}

			if (Main.rand.NextBool(4)) target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(4, 8));
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (Main.rand.NextBool(4)) target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(4, 8));
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			//goBack = true;
			Projectile.tileCollide = false;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.92f;
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			return false;
        }
	}   
}