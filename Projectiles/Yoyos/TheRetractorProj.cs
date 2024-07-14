using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
    public class TheRetractorProj : ModProjectile
    {
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 45;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
        }
        float light = Main.rand.NextFloat(0f, 0.5f);
        float dark = Main.rand.NextFloat(0f, 0.5f);
        public override void AI() {
            Projectile.velocity *= 0.88f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;

            float glow = light-dark;
            if (glow > 0f) Lighting.AddLight(Projectile.Center, Color.White.ToVector3()*glow*3f);

            if (Projectile.timeLeft < 10) Projectile.alpha += 25;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D lightTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Yoyos/TheRetractorProj_Light");
            Texture2D darkTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Yoyos/TheRetractorProj_Dark");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(13, 13); //+ drawOrigin
                Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect*((255-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                Main.spriteBatch.Draw(darkTexture, drawPosEffect, null, colorAfterEffect*dark*((255-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                Main.spriteBatch.Draw(lightTexture, drawPosEffect, null, colorAfterEffect*light*((255-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White*((255-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(darkTexture, drawPos, null, Color.White*dark*((255-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(lightTexture, drawPos, null, Color.White*light*((255-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}