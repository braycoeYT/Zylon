using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bows
{
	public class DirkbowProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 360;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
		}
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
			else if (Projectile.alpha > 0) Projectile.alpha -= 17;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
			float finalAlpha = 1f-(Projectile.alpha/255f);
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bows/DirkbowProj_Dark");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			for (int k = 0; k < Projectile.oldPos.Length; k++) { //Dark shadow
				//float trailLightAlpha = (float)(k/8f); //og 15f
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + Projectile.velocity*(k/2f);
                //Main.EntitySpriteDraw(texture, drawPos, null, Color.White*finalAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				Main.EntitySpriteDraw(altTexture, drawPos, null, Color.White*finalAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			for (int k = 0; k < Projectile.oldPos.Length; k++) { //Main light effect
				float trailLightAlpha = (float)(k/8f); //og 15f
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + Projectile.velocity*(k/2f);
                Main.EntitySpriteDraw(texture, drawPos, null, Color.White*finalAlpha*trailLightAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				//Main.EntitySpriteDraw(altTexture, drawPos, null, Color.White*finalAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			/*for (int k = 0; k < Projectile.oldPos.Length; k++) {
				float trailLightAlpha = (float)(k/8f); //og 15f
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + Projectile.velocity*(k/2f);
                Main.EntitySpriteDraw(texture, drawPos, null, Color.White*finalAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				Main.EntitySpriteDraw(altTexture, drawPos, null, Color.White*finalAlpha*trailLightAlpha, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }*/

			//Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*finalAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			//Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*finalAlpha*lightAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}