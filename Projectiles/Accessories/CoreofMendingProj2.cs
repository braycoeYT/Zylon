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
	public class CoreofMendingProj2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 13;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
		}
		int Timer;
		float speedAcc;
		bool hpBoost;
		public override void AI() {
            Projectile.netUpdate = true;
			Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
			if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
				hpBoost = true;
				Projectile.Kill();
			}
			speed.Normalize();
			speedAcc += 0.01f;
			if (speedAcc > 1f) speedAcc = 1f;
			Projectile.velocity = speed*-20f*speedAcc;

			Projectile.rotation += 0.0125f;
			Projectile.scale = 1.25f + (float)Math.Sin(Main.GameUpdateCount/20f)/4f;

            //Lighting.AddLight(Projectile.Center, Color.LightSkyBlue.ToVector3() * 0.8f);
        }
        public override void OnKill(int timeLeft) {
            if (hpBoost) {
                SoundEngine.PlaySound(SoundID.NPCDeath39.WithPitchOffset(1f).WithVolumeScale(0.5f), Projectile.position);

				int rand = Main.rand.Next(3, 6);
				Main.player[Projectile.owner].Heal(rand);

                for (int i = 0; i < 5; i++) {
				    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch);
			    	dust.noGravity = false;
				    dust.scale = Main.rand.NextFloat(0.75f, 1f);
					dust.velocity = Vector2.Normalize(Projectile.velocity).RotatedByRandom(MathHelper.ToRadians(60f))*8f;
			    }
            }
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			return false;
        }
	}   
}