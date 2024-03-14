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
	public class WretchedWrench : ModProjectile
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
		bool stuck;
		NPC stuckTarget;
		Vector2 safe;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.3f;

			if (stuck) {
				Projectile.rotation += 0.2f;
				Projectile.width = 60;
				Projectile.height = 60;
				Projectile.Center = stuckTarget.Center - safe;
				if (!stuckTarget.active) Projectile.Kill();
				return;
            }

			if (Timer >= 50 || goBack) {
				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.1f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-25f*speedAcc;
			}
			else if (Timer >= 35) Projectile.velocity *= 0.95f;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (Main.rand.NextBool(5) && !stuck) { //Sets up "stuck" state.
				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				stuck = true;
				stuckTarget = target;
				Projectile.usesLocalNPCImmunity = true;
				Projectile.localNPCHitCooldown = 3;
				Projectile.damage = (int)(Projectile.damage*0.75f);
				if (Projectile.damage < 1) Projectile.damage = 1;
				Projectile.penetrate = 20;
				Projectile.tileCollide = false;
				safe = target.Center - Projectile.Center;
				Projectile.timeLeft = 180;
			}
			if (stuck) return;

			Projectile.damage = (int)(Projectile.damage*0.8f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
        }
		public override void PostAI() {
            if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpookyWood);
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
        public override void OnKill(int timeLeft) {
			if (stuck) for (int i = 0; i < 6; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpookyWood);
				dust.noGravity = false;
				dust.scale = 2f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
            // This just grabs the projectiles texture, with the one below it grabbing the "overlay" which we use for the after effect
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/WretchedWrench_trail");

            // Grabs the draw origin of the projectile by making a Vector2 that grabs the width and height of the projectile.
            // Grabbing the width of the actual texture makes things more centered.
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            // This code right here draws the after images of the projectile.
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                // This grabs where the image should be drawn by pretty much doing the same process as the one above but with the old position.
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                // Funny fade.
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                // This actually draws the trail effect. Take note of the Projectile.oldRot[k].
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}