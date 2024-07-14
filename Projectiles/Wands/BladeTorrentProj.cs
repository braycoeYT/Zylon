using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class BladeTorrentProj : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.alpha = 255;
		}
        public override void AI() {
            if (Projectile.timeLeft > (int)Projectile.ai[0]) Projectile.timeLeft = (int)Projectile.ai[0];
            if (Projectile.alpha > 0) Projectile.alpha -= 17;
            Projectile.friendly = Projectile.alpha == 0;
        }
		public override void PostAI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
		}
        Color drawColor = new Color(128+Main.rand.Next(128), 128+Main.rand.Next(128), 128+Main.rand.Next(128)); //new Color(Main.rand.Next(256), Main.rand.Next(256), Main.rand.Next(256));
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = drawColor*((255-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + Projectile.velocity*0.85f*k;// - new Vector2(Projectile.width/2, Projectile.height/2);
                float asdf = 0.65f;
                if (k == 0) asdf = 1f;
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * asdf;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            //Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }   
}