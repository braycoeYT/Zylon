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
	public class EtherealGaspProj : ModProjectile
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
			Projectile.timeLeft = 900;
			Projectile.tileCollide = false;
		}
		float speedAcc;
		bool possess;
		public override void AI() {
			Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
				possess = true;
				Projectile.Kill();
			}
			speed.Normalize();
			speedAcc += 0.005f;
			if (speedAcc > 1f) speedAcc = 1f;
			Projectile.velocity = speed*-12f*speedAcc;

            //for (int i = 0; i < 2; i++) {
			    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit);
			   	dust.noGravity = false;
			    dust.scale = 1.25f;
			//}
        }
        public override void OnKill(int timeLeft) {
            if (possess) {
                SoundEngine.PlaySound(SoundID.NPCDeath39, Projectile.position);
                Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.Accessories.Possessed>(), 360);
            }
            for (int i = 0; i < 3; i++) {
			    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit);
			  	dust.noGravity = false;
				dust.scale = 1.75f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/EtherealGaspProj");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*(30-k)/30, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}