using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.States;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Guns
{
	public class PoltergeistProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 180;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.alpha = 255;
		}
		int Timer;
		int animTimer = Main.rand.Next(30);
		bool init;
		Vector2 baseVel;
        public override void AI() {
			Projectile.tileCollide = Projectile.timeLeft < 140;

			if (!init) {
				Projectile.rotation = Projectile.velocity.ToRotation();
				baseVel = Vector2.Normalize(Projectile.velocity)*0.5f;
				Projectile.velocity = baseVel;
				init = true;
			}
			Timer++;
			if (Timer < (int)Projectile.ai[0]) {
				Projectile.timeLeft = 180;
				return;
			}

			animTimer++;

			if (Projectile.timeLeft < 17) {
                if (Projectile.alpha < 0) Projectile.alpha = 0;
                Projectile.alpha += 15;
            }
            else Projectile.alpha -= 15;
			
			//Velocity
			if (Projectile.timeLeft <= 170) {
				if (Projectile.velocity.Length() < 16f) Projectile.velocity *= 1.3f;
			}
			//else Projectile.velocity = baseVel;

			//Rot fix
			Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
			//if (Projectile.alpha == 255) return false;
			float lightAlpha = 1f-((animTimer%30)/30f);
			float finalAlpha = 1f-(Projectile.alpha/255f);
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Guns/PoltergeistProj_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				float trailLightAlpha = 1f-(((animTimer-k-1)%30)/30f);
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Main.EntitySpriteDraw(texture, drawPos, null, Color.White*finalAlpha, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				Main.EntitySpriteDraw(altTexture, drawPos, null, Color.White*finalAlpha*trailLightAlpha, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			//Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*finalAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			//Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*finalAlpha*lightAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}