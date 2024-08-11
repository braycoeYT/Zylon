using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class CloudNineProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
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
		bool returnProj;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.23f;

			if (Timer >= 25 || goBack) {
				if (Projectile.ai[1] == 1f && !returnProj) {
					if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 9; i++)
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 10).RotatedBy(MathHelper.ToRadians(i*40)), ModContent.ProjectileType<CloudNineProj_Mini>(), (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.6f, Projectile.owner);
					returnProj = true;
                }

				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.07f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-27f*speedAcc;
			}
			else if (Timer >= 15) Projectile.velocity *= 0.92f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.damage = (int)(Projectile.damage*0.8f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
		}
		public override void PostAI() {
            if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud);
				dust.noGravity = false;
				dust.scale = 1f;
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
			return false;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(7, 8); //- new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}