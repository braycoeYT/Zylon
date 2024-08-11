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
	public class Mephiles_ShadowExplosion : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 45;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.scale = 1f;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void AI() {
            Projectile.scale = 1.5f - (float)Projectile.timeLeft/30;
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = (Projectile.oldPos[k] + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + drawOrigin - new Vector2(10, 10);
                Color colorAfterEffect = Color.White * ((255f - Projectile.alpha) / 255f) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
				if (k == 0) colorAfterEffect = Color.White * ((255f - Projectile.alpha) / 255f);
                Main.spriteBatch.Draw(texture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, 1.5f - (Projectile.timeLeft+k)/30f, SpriteEffects.None, 0);
            }

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White * ((255f - Projectile.alpha) / 255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), 1.5f - Projectile.timeLeft/30f, effects, 0);
			return false;
		}
	}   
}