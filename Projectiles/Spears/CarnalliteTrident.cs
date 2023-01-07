using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class CarnalliteTrident : SpearProj
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Carnallite Trident");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
		}
        public override void SpearDefaultsSafe()
        {
			Projectile.width = 44;
			Projectile.height = 44;
		}

        public override void SpearDrawBefore(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
        {
			if (SwingNumber >= 0 && SwingNumber <= 1)
            {
				for (int k = 0; k < Projectile.oldPos.Length; k++)
				{
					Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
					Color colorAfterEffect = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
					spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle(0, 0, projectileTexture.Width, (projectileTexture.Height / amountOfExtras)), colorAfterEffect, drawRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				}
			}
		}

        public override void FreezeFramesExtraEffect()
        {
			for (int i = 0; i < 6; i++)
            {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CarnalliteDust>());
				dust.noGravity = true;
				dust.scale = 2f;
				dust.velocity = new Vector2(Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f));
			}
		}

        public CarnalliteTrident() : base(-23f, 29, 360f, 325f, 5, 24, 70f, 14.3f, 3f, false, true, true) { }

		public override void PostAI() {
			if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CarnalliteDust>());
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}
	}
}