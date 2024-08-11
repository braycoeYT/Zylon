using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class CogwheelProj_Cog : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 40;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 40;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextBool(25) && !target.boss) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), 60);
        }
        public override void AI() {
			Projectile.velocity *= 0.93f;
			Projectile.rotation += 0.05f;
			if (Projectile.timeLeft < 5) Projectile.alpha += 51;
        }
        public override void PostAI() {
			//Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SteampunkSteam);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, spriteEffects, 0);
            }
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0f);
            return false;
        }
	}   
}