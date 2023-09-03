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
	public class BionicBoomerRang : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bionic Boomer");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.2f;
			if (Timer >= 30 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.03f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-15f*speedAcc;
			}
			else if (Timer >= 15) Projectile.velocity *= 0.95f;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			goBack = true;
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
	}   
}