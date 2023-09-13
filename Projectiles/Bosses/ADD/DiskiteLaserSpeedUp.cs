using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class DiskiteLaserSpeedUp : ModProjectile
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Sun Ray");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
		}
		public override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 80;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}

		const int appearTime = 20;
		const int telegraphTime = 60;
		const int slashMoveTime = 40;
		const int slashFadeAway = 10;

		const int slashExtraUpdates = 4;
        public override void AI() {

			if (Projectile.ai[0] == 0)
            {
				SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.Center);
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				Projectile.velocity = Vector2.Zero;
			}
			Projectile.ai[0]++;

			if (Projectile.ai[0] <= appearTime)
            {
				GlobalFakeScale = Projectile.ai[0] / (float)appearTime;

			} else if (Projectile.ai[0] - appearTime <= telegraphTime)
            {
				Projectile.velocity = -new Vector2(15f/telegraphTime, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2) + -new Vector2(5f / telegraphTime, 0f).RotatedBy(Projectile.rotation);
				telegraphOpacity = ((Projectile.ai[0] - appearTime) / (float)telegraphTime) * 1.5f;
			} else if ((Projectile.ai[0] - appearTime) - telegraphTime >= slashMoveTime * slashExtraUpdates)
			{
				Projectile.extraUpdates = 1;
				for (int k = 0; k < 2; k++)
                {
					Projectile.oldPos[0] = Projectile.Center;
					for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
					{
						Projectile.oldPos[i] = Projectile.oldPos[i - 1];
					}
				}
				if (Projectile.ai[0] > appearTime + telegraphTime + (slashMoveTime * Projectile.extraUpdates) + slashFadeAway)
				{
					Projectile.Kill();
				}
			} else
			{
				if ((Projectile.ai[0] - appearTime) - telegraphTime == 1)
                {
					Systems.Camera.CameraController.ScreenshakePoints(5, 650, Main.player[Main.myPlayer].Center, Projectile.Center, 1.5f);
					SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Projectiles/FlareSlash") { Volume = 0.2f, PitchVariance = 1.8f, MaxInstances = 20, }, Projectile.Center);
				}

				Projectile.velocity = new Vector2(40f, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2);
				Projectile.extraUpdates = slashExtraUpdates;
				if (Projectile.ai[0] % 3 == 0)
                {
					drawSlash = true;
					Projectile.oldPos[0] = Projectile.Center;
					for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
					{
						Projectile.oldPos[i] = Projectile.oldPos[i - 1];
					}
				}
			}
			Projectile.timeLeft = 2;
        }
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

		float GlobalFakeScale = 0f;
		bool drawSlash = false;
		float telegraphOpacity = 0f;
		public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D overlayTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ADD/DiskiteLaserSpeedUp_overlay");
			Texture2D sphereGlow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");

			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

			Vector2 drawOrigin = texture.Size() * 0.5f;
			Vector2 glowOrigins = sphereGlow.Size() * 0.5f;
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

			Color color = Projectile.GetAlpha(Color.White);
			Color glowColor = Projectile.GetAlpha(new Color(255, 186, 64)) * 0.25f;
			if (!drawSlash)
            {
				Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2(0.2f, 1f) * 2f, effects, 0);

				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, GlobalFakeScale, effects, 0);

				if (telegraphOpacity > 0)
                {
					Main.EntitySpriteDraw(sphereGlow, drawPos + new Vector2(740f, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2), null, glowColor * telegraphOpacity, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2((float)Math.Abs(Math.Sin(Projectile.ai[0] * 0.1f)) * 0.13f, 6f) * 2f, effects, 0);
					Main.EntitySpriteDraw(sphereGlow, drawPos + new Vector2(740f, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2), null, glowColor * telegraphOpacity, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2((float)Math.Abs(Math.Sin((Projectile.ai[0] * 0.1f) + Math.PI)) * 0.13f, 6f) * 2f, effects, 0);
					Main.EntitySpriteDraw(sphereGlow, drawPos + new Vector2(740f, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2), null, glowColor * telegraphOpacity * 2.5f, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2(0.03f, 6f) * 2f, effects, 0);
					Main.EntitySpriteDraw(overlayTexture, drawPos + new Vector2(20f * (1f - ((Projectile.ai[0] - appearTime) / (float)telegraphTime)), 0f).RotatedBy(Projectile.rotation), null, color * telegraphOpacity * 0.6f, Projectile.rotation, drawOrigin, GlobalFakeScale, effects, 0);
					Main.EntitySpriteDraw(overlayTexture, drawPos + -new Vector2(20f * (1f - ((Projectile.ai[0] - appearTime) / (float)telegraphTime)), 0f).RotatedBy(Projectile.rotation), null, color * telegraphOpacity * 0.6f, Projectile.rotation, drawOrigin, GlobalFakeScale, effects, 0);
				}

				if (GlobalFakeScale < 1)
				{
					Main.EntitySpriteDraw(overlayTexture, drawPos, null, color * (1f - GlobalFakeScale), Projectile.rotation, drawOrigin, GlobalFakeScale, effects, 0);
				}

				Main.EntitySpriteDraw(sphereGlow, drawPos, null, glowColor * 0.75f, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2(0.1f, 1f) * 1.25f, effects, 0);
			} else
            {
				for (int k = 0; k < Projectile.oldPos.Length; k++)
				{
					Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
					Color colorAfterEffect = glowColor * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 3f;
					Main.spriteBatch.Draw(sphereGlow, drawPosEffect, null, colorAfterEffect, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2(0.2f, 1f) * 2f, SpriteEffects.None, 0);
					Main.spriteBatch.Draw(sphereGlow, drawPosEffect + new Vector2(120f, 0f).RotatedBy(Projectile.rotation - MathHelper.PiOver2), null, colorAfterEffect * 0.45f, Projectile.rotation, glowOrigins, GlobalFakeScale * new Vector2(0.2f, 2f) * 2f, SpriteEffects.None, 0);
				}
			}
			return false;
		}
	}   
}