using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Plantainarang : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		bool done;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.5f;
			if (Timer >= 35 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-32f*speedAcc;
			}
			else if (Timer >= 20) Projectile.velocity *= 0.95f;
		}
        /*public override void PostAI() {
            if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}*/
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.tileCollide = false;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.92f;
			return false;
        }
		int hitCount;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			hitCount++;

			Projectile.damage = (int)(Projectile.damage*0.85f);
			if (Projectile.damage < 1) Projectile.damage = 1;

			int healNum = (int)(Projectile.damage*0.15f);
			if (healNum < 1) healNum = 1;
			if (Main.rand.NextFloat() < .02f && hitCount < 2) Main.player[Projectile.owner].Heal(healNum);
        }
    }   
}