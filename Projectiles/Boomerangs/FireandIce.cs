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
	public class FireandIce : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fire and Ice");
        }
		public override void SetDefaults() {
			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.3f;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.08f;
			if (Timer >= 50 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Timer == 50) for (int i = 0; i < 3; i++) {
					int projType = ModContent.ProjectileType<FireandIce_1>();
					if (Main.rand.NextBool()) projType = ModContent.ProjectileType<FireandIce_2>();
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.Next(-8, -4)), projType, (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Main.myPlayer);
				}
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					for (int i = 0; i < 5; i++) {
						Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
						dust.noGravity = false;
						dust.scale = 2f;
					}
					for (int i = 0; i < 5; i++) {
						Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
						dust.noGravity = false;
						dust.scale = 2f;
					}
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-15f*speedAcc;
			}
			else if (Timer >= 35) Projectile.velocity *= 0.95f;
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
			return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 8) * 60);
			target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8) * 60);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 8) * 60);
			target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8) * 60);
		}
	}   
}