using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class SnowfallProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Snowfall");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 75;
			Projectile.alpha = 255;
			Projectile.rotation = Main.rand.NextFloat(6.28f);
			Projectile.tileCollide = false;
		}

		Vector2 StoredMouse = Vector2.Zero;
		Vector2 StoredCenter = Vector2.Zero;
		Vector2 StoredVelocity = Vector2.Zero;

		readonly float RampSpeed = 30f;
		float progress;
		public override void AI() {
			Projectile.alpha -= 45;
            Projectile.ai[0]++;
			Projectile.velocity *= 0.98f;

			progress = (Projectile.ai[0] / RampSpeed);
			Projectile.tileCollide = !(Projectile.ai[0] <= (RampSpeed / 0.8f));

			if (Main.rand.NextBool(5))
            {
				Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<Dusts.SnowfallDust>(), Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3), Projectile.alpha, Color.White, 1f);
			}


			if (Projectile.owner == Main.myPlayer)
            {
				if (Projectile.ai[0] <= 1)
                {
					StoredMouse = Main.MouseWorld;
					StoredCenter = Projectile.Center;
					StoredVelocity = Projectile.velocity;
				}
				if (Projectile.ai[0] <= (RampSpeed + 3f))
				{
					Projectile.velocity = Vector2.SmoothStep(StoredVelocity, (StoredMouse - StoredCenter).SafeNormalize(Vector2.Zero) * 12f, progress);

					Projectile.netUpdate = true;
				}
            }

			if (Projectile.ai[0] >= (RampSpeed - 7f))
            {
				Projectile.rotation += (Projectile.ai[0]/275f);
            }

		}
		public override void Kill(int timeLeft) {
			for (int d = 0; d < 4; d++)
			{
				Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<Dusts.SnowfallDust>(), Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(-6, 6), 0, Color.White, 1.3f);
			}
		}

		float fakealpha = 1f;
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D trail = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/SnowfallProj_trail");

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(Color.White) * fakealpha;

			float FakeScale = 1f;

			if (Projectile.ai[0] <= (RampSpeed + 3f))
            {
				FakeScale = MathHelper.SmoothStep(0.65f, 1f, progress);
			} 
			if ((RampSpeed - 10) >= Projectile.timeLeft) 
			{
				fakealpha -= 0.05f;
			}


			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
				Main.spriteBatch.Draw(trail, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, FakeScale - k / (float)Projectile.oldPos.Length / 3, SpriteEffects.None, 0);
			}

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, FakeScale, SpriteEffects.None, 0f);

			return false;
		}

	}   
}