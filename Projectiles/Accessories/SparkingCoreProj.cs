using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Accessories
{
	public class SparkingCoreProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 600;
			Projectile.tileCollide = false;
		}
		int Timer;
		float speedAcc;
		bool manaBoost;
		public override void AI() {
			Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
			if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
				manaBoost = true;
				Projectile.Kill();
			}
			speed.Normalize();
			speedAcc += 0.01f;
			if (speedAcc > 1f) speedAcc = 1f;
			Projectile.velocity = speed*-35f*speedAcc;

            Lighting.AddLight(Projectile.Center, Color.LightSkyBlue.ToVector3() * 0.8f);
        }
        public override void OnKill(int timeLeft) {
            if (manaBoost) {
                SoundEngine.PlaySound(SoundID.Item29.WithVolumeScale(0.5f), Projectile.position);
                Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.Accessories.GraniteEnergyBoost>(), 300);
                for (int i = 0; i < 5; i++) {
				    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
			    	dust.noGravity = false;
				    dust.scale = 2f;
			    }
            }
        }
        public override bool PreDraw(ref Color lightColor) {
            // This just grabs the projectiles texture, with the one below it grabbing the "overlay" which we use for the after effect
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/SparkingCoreProj");

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
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*(30-k)/30, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}