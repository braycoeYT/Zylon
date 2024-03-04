using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Misc
{
	public class MagnificentOrbStar : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Magnificent Star");

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 255;
		}

        public override void AI()
        {
            Projectile.alpha -= 30;
            Projectile.rotation += 0.2f;

            if (Projectile.alpha < 30 && Main.rand.NextBool(3))
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MagnificentDust>(), (Projectile.velocity.X / 1.5f) + Main.rand.NextFloat(-1.2f, 1.2f), (Projectile.velocity.Y / 1.5f) + Main.rand.NextFloat(-1.2f, 1.2f), 0, Color.White, 1.3f);
            }



            if (Projectile.timeLeft < 30)
            {
                if (Projectile.alpha < 0)
                    Projectile.alpha = 0;

                Projectile.alpha += 30;
            }

        }


        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            for (int d = 0; d < 12; d++)
            {
                Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<Dusts.MagnificentDust>(), Main.rand.NextFloat(-12, 12), Main.rand.NextFloat(-12, 12), 0, Color.White, 1.3f);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Misc/MagnificentOrbStar_glow");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);
            Color color2 = Projectile.GetAlpha(Color.White);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                Color colorAfterEffect2 = color2 * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect * 0.1f, Projectile.oldRot[k], drawOrigin, Projectile.scale * 1.6f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect * 0.2f, Projectile.oldRot[k], drawOrigin, Projectile.scale * 1.4f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect * 0.3f, Projectile.oldRot[k], drawOrigin, Projectile.scale * 1.2f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                Main.spriteBatch.Draw(glow, drawPosEffect, null, colorAfterEffect2, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color * 0.1f, Projectile.rotation, drawOrigin, Projectile.scale * 1.6f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color * 0.2f, Projectile.rotation, drawOrigin, Projectile.scale * 1.4f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color * 0.3f, Projectile.rotation, drawOrigin, Projectile.scale * 1.2f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(glow, drawPos, null, color2, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}