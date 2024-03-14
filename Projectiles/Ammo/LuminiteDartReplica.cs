using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Ammo
{
	public class LuminiteDartReplica : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 9999;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
		}
        int Timer;
        bool a;
        bool dead;
        NPC target;
        Vector2 targetPos;
        public override void AI() {
            if (!dead) {
                target = Main.npc[(int)Projectile.ai[0]];
                targetPos = target.Center;
            }
            if (!target.active) dead = true;
            if (!a) {
                Timer = (int)(Projectile.ai[1]*-60-30);
                a = true;
            }
            Timer++;
            if (Timer == 0) {
                Projectile.Center = targetPos + new Vector2(0, 60).RotatedByRandom(MathHelper.TwoPi);
                Projectile.velocity = Vector2.Normalize(Projectile.Center - targetPos)*-5f;
                Projectile.timeLeft = 24;
                Projectile.alpha = 0;
                Projectile.friendly = true;
                SoundEngine.PlaySound(SoundID.Item101);
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override bool PreDraw(ref Color lightColor) {
            // This just grabs the projectiles texture, with the one below it grabbing the "overlay" which we use for the after effect
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Ammo/LuminiteDartReplica");

            // Grabs the draw origin of the projectile by making a Vector2 that grabs the width and height of the projectile.
            // Grabbing the width of the actual texture makes things more centered.
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            // This code right here draws the after images of the projectile.
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                // This grabs where the image should be drawn by pretty much doing the same process as the one above but with the old position.
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                // Funny fade.
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                // This actually draws the trail effect. Take note of the Projectile.oldRot[k].
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}