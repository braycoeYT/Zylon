using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class HideousDucklingProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
		}
		bool reverse;
		Vector2 finalVel;
        public override bool PreAI() {
			if (reverse) {
				Projectile.velocity = finalVel - finalVel*3f*((60f-Projectile.timeLeft)/60f);
			}
			if (Projectile.timeLeft < 20) Projectile.alpha += 13;
            return !reverse;
        }
        public override void AI() {
			if (Main.GameUpdateCount % 120 == 0 && !reverse) {
				finalVel = Projectile.velocity;
				reverse = true;
				Projectile.timeLeft = 60;
				Projectile.tileCollide = false;
			}
        }
        public override void PostAI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Lighting.AddLight(Projectile.Center, 0.111f, 0.001f, 0.023f);
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White*((255-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width/2, Projectile.height/2); // + drawOrigin - 
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.65f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Crimstone);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.75f, 1.25f);
				dust.velocity = new Vector2(0, -5).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}