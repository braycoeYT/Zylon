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
	public class BiDisc : ModProjectile
	{
		//og proj is 0f, clones are 1f
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
		bool clone;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.2f;
			if (Timer >= 15 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.08f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-25f*speedAcc;
			}
			else if (Timer >= 5) Projectile.velocity *= 0.95f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.6f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JadeDust2>());
				dust.noGravity = true;
				dust.scale = 2f;
			}
			SoundEngine.PlaySound(SoundID.Item25);
			if (Projectile.ai[0] == 0f && Main.myPlayer == Projectile.owner && Main.rand.NextBool(10) && !clone) {
				float rand = Main.rand.NextFloat(MathHelper.TwoPi);
				for (int i = 0; i < 4; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 20).RotatedBy(MathHelper.ToRadians(i*90)+rand), Projectile.type, (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.75f, Projectile.owner, 1f);
                }
				clone = true;
            }
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
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JadeDust2>());
				dust.noGravity = true;
				dust.scale = 2f;
			}
			return false;
        }
	}   
}