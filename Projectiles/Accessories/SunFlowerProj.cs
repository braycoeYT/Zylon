using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rail;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Accessories
{
	public class SunFlowerProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
            Projectile.alpha = 255;
		}
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (target.Center.X < Main.player[Projectile.owner].Center.X) modifiers.HitDirectionOverride = -1;
            else modifiers.HitDirectionOverride = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(8, 16)*60);
        }
        public override void AI() {
            Projectile.friendly = true; Projectile.hostile = false; //In case enemies use the projectile reflect on it.

            Projectile.timeLeft = 9999;
			Player owner = Main.player[Projectile.owner];
            ZylonPlayer p = owner.GetModPlayer<ZylonPlayer>();

            if (owner.statLifeMax2/2 > owner.statLife || !p.sunFlower) Projectile.alpha -= 17;
            else Projectile.alpha += 17;

            if (Projectile.alpha >= 255) Projectile.Kill();
            if (Projectile.alpha < 0) Projectile.alpha = 0;

            Projectile.Center = owner.Center;
            Projectile.rotation += 0.05f;
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White*((255f-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);// + new Vector2(31, 31);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}