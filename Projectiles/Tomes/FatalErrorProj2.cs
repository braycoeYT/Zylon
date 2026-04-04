using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;

namespace Zylon.Projectiles.Tomes
{
	public class FatalErrorProj2 : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.timeLeft = 120;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
		}
		bool init;
		int Timer;
		float transition;
        public override void AI() { //ai0 = transferred transition | ai1 = transferred rotation
			if (!init) {
				transition = Projectile.ai[0];
				init = true;
			}

			Projectile.velocity = Vector2.Zero;

			int x = 0;
			if (Main.rand.Next(45) < Timer) { //Less erratic at first.
				if (Main.rand.NextBool(3)) x = -8;
				else if (Main.rand.NextBool(2)) x = 8;

				Projectile.friendly = Timer > 5;
			}
			int y = 0;
			if (Main.rand.Next(45) < Timer) { //Less erratic at first.
				if (Main.rand.NextBool(3)) y = -8;
				else if (Main.rand.NextBool(2)) y = 8;

				Projectile.friendly = Timer > 5;
			}
			Projectile.position += new Vector2(x, y).RotatedBy(Projectile.ai[1]);
			Projectile.rotation = Projectile.ai[1];

			Timer++;
			if (Timer > 29) transition += 0.04f;
			if (transition > 1f) transition = 1f;

			if (Projectile.timeLeft < 15) Projectile.alpha += 17;

			Lighting.AddLight(Projectile.Center, Color.Lime.ToVector3() * 0.2f * (1f-transition));
			Lighting.AddLight(Projectile.Center, Color.Red.ToVector3() * 0.2f * transition);
        }
		public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D red = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/FatalErrorProj2_Red");
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White*((255f-Projectile.alpha)/255f);

		    if (transition < 1f) for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
			for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(red, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect*transition, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    if (transition < 1f) Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
		    Main.spriteBatch.Draw(red, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color*transition, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

		    return false;
		}
	}   
}