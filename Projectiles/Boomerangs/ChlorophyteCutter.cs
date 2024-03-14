using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class ChlorophyteCutter : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
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
			Projectile.rotation += 0.3f;

			if (Timer >= 30 || goBack) {
				if (!returnProj) {
					if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 8; i++)
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 13).RotatedBy(MathHelper.ToRadians(i*45)), ProjectileID.SporeCloud, (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.6f, Projectile.owner);
					returnProj = true;
                }

				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.06f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-35f*speedAcc;
			}
			else if (Timer >= 15) Projectile.velocity *= 0.95f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.damage = (int)(Projectile.damage*0.9f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
			if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 8; i++)
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 13).RotatedBy(MathHelper.ToRadians(i*45)), ProjectileID.SporeCloud, (int)(Projectile.originalDamage*0.75f), Projectile.knockBack*0.6f, Projectile.owner);
        }
		public override void PostAI() {
            if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.ChlorophyteWeapon);
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
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/ChlorophyteCutter_Trail");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}