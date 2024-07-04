using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Blowpipes
{
	public class HollowKnifeProj2 : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            kill = true;
        }
        bool kill;
        int targetNum;
		bool init;
		Color drawColor = new (Main.rand.Next(63, 180), Main.rand.Next(63, 180), Main.rand.Next(63, 180), 255);
        public override void AI() {
			if (!init) {
				targetNum = (int)Projectile.ai[0];
				init = true;

				if (targetNum >= 0 && Main.npc[targetNum].active && Main.npc[targetNum].type != NPCID.TargetDummy) {
					Projectile.timeLeft = 180;
					Projectile.velocity = Projectile.DirectionTo(Main.npc[targetNum].Center)*24f;
				}
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;

			if (Projectile.timeLeft < 15 || kill) Projectile.alpha += 17;
			else if (Projectile.alpha > 0) {
				Projectile.alpha -= 17;
			}
        }
        public override void OnKill(int timeLeft) {
			if (Projectile.alpha < 100) Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Blowpipes/HollowKnifeProj2");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = new Color(drawColor.R, drawColor.G, drawColor.B, 255-Projectile.alpha);

			float mult = 1f;
			if (Projectile.timeLeft < 15) {
				mult = Projectile.timeLeft/15f;
			}

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect*mult, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color*mult, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}