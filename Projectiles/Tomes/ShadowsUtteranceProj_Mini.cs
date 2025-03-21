using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class ShadowsUtteranceProj_Mini : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.4f);
        }
		bool init;
        int Timer;
		public override void AI() {
			if (!init) {
				Timer = (int)Projectile.ai[0]*-3; //- 20;
				init = true;
			}
			Timer++;
			if (Timer < 20) {
				Projectile.velocity *= 0.95f;
			}
			else if (Timer == 20) {
				Projectile.velocity = Projectile.Center.DirectionTo(Main.MouseWorld);
				Projectile.timeLeft = 90;
				Projectile.penetrate = 1;
			}
			else {
				Projectile.velocity *= 1.1f;
				if (Projectile.velocity.Length() > 32) Projectile.velocity = Vector2.Normalize(Projectile.velocity)*32f;

				if (Timer < 80) {
					Projectile.velocity = Projectile.velocity*0.8f + Projectile.Center.DirectionTo(Main.MouseWorld)*Projectile.velocity.Length()*0.2f;
				}
			}

			Projectile.rotation += 0.05f*Projectile.velocity.Length() + 0.05f;
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			return false;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY); // - new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
				if (k == 0) colorAfterEffect = color;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect*((255f-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color*((255f-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}