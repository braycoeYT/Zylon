using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Stone
{
    public class StoneBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Ball");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = Projectile.localNPCHitCooldown = 600;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
        }



        private readonly float GravityWait = 16f;
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.velocity.Length() >= 6f)
            {
                Projectile.rotation += 0.1f;
            } else
            {
                Projectile.rotation += (Projectile.velocity.Length() / 90f);
            }

            if (Projectile.velocity.Length() >= 0.55f || Projectile.ai[1] == 0)
            {
                if (Projectile.ai[0] >= GravityWait)
                    Projectile.velocity.Y += 0.55f;
                if (Projectile.velocity.Y >= 16f)
                    Projectile.velocity.Y = 16f;
            } else
            {
                Projectile.velocity.Y += 0.07f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.ai[1]++;
            if (oldVelocity.Length() >= 9f)
            {
                Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
                for (int a = 0; a < 21; a++)
                {
                    Dust killDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.StoneDust>());
                    killDust.velocity *= 1.8f;
                }
            }
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            Projectile.velocity *= 0.55f;

            if (oldVelocity.Length() <= 0.25f)
            {
                Projectile.friendly = false;
            } else
            {
                Projectile.friendly = true;
            }
            if (oldVelocity.Length() <= 0.15f)
            {
                Projectile.Kill();
            }

            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int a = 0; a < 51; a++)
            {
                Dust killDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.StoneDust>());
                killDust.velocity *= 1.8f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item127, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Stone/StoneBall_overlay");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = new Color(190, 190, 255) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k/8f)) + Projectile.scale;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect * (1f - (Projectile.ai[0] / (GravityWait * 1.5f))), Projectile.rotation, drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(overlay, drawPos, null, color * (1f - (Projectile.ai[0] / (GravityWait * 1.5f))), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}