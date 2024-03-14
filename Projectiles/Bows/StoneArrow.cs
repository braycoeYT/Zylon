using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bows
{
    public class StoneArrow : ModProjectile
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Stone Arrow");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults() {
            Projectile.width = 14;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        readonly float GravityWait = 16f;
        public override void AI() {
            if (Projectile.ai[0] == 0) {
                for (int a = 0; a < 7; a++) {
                    Dust SpawnDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.StoneDust>(), Projectile.velocity.X + Main.rand.NextFloat(-0.3f, 0.3f), Projectile.velocity.Y + Main.rand.NextFloat(-0.3f, 0.3f));
                    SpawnDust.velocity *= 0.853f;
                }
                SoundEngine.PlaySound(SoundID.Item5, Projectile.position);
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= GravityWait)
                Projectile.velocity.Y += 0.55f;
            if (Projectile.velocity.Y >= 16f)
                Projectile.velocity.Y = 16f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnKill(int timeLeft) {
            for (int a = 0; a < 21; a++) {
                Dust killDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.StoneDust>());
                killDust.velocity *= 1.8f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item127, Projectile.position);
        }
        public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bows/StoneArrow_overlay");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k / 8f)) + Projectile.scale;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, AfterAffectScale, spriteEffects, 0);
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect * (1f - (Projectile.ai[0] / (GravityWait * 1.5f))), Projectile.rotation, drawOrigin, AfterAffectScale, spriteEffects, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
            Main.spriteBatch.Draw(overlay, drawPos, null, color * (1f - (Projectile.ai[0] / (GravityWait * 1.5f))), Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);

            return false;
        }
    }
}