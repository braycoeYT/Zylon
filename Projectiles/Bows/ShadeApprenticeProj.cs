using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bows
{
	public class ShadeApprenticeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.timeLeft = 600;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.5f);
        }
        int Timer;
		int startTimer;
        public override bool PreAI() {
			if (Projectile.alpha > 0) {
				Projectile.timeLeft = 180;

				if (!Main.projectile[(int)Projectile.ai[0]].active) Projectile.alpha -= 17;
				else {
					Projectile.Center = Main.projectile[(int)Projectile.ai[0]].Center;
					Projectile.velocity = Vector2.Normalize(Main.projectile[(int)Projectile.ai[0]].velocity)*10f;
				}
			}
            return Projectile.alpha < 1;
        }
        public override void AI() {
			Projectile.rotation += 0.05f*Projectile.velocity.Length() + 0.05f;
			Projectile.friendly = true;

			startTimer++;
			if (startTimer < 20) {
				Projectile.velocity *= 0.93f;
				return;
			}

			Timer++;
			if (Timer > 100) Timer = 100;

			Projectile.velocity = Projectile.Center.DirectionTo(Main.player[Projectile.owner].Center)*32f*(Timer/100f);

			if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) < 24f) Projectile.Kill();
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
			   	dust.noGravity = false;
				dust.scale = Main.rand.NextFloat(1.75f, 2f);
				dust.velocity = Vector2.Normalize(Projectile.velocity).RotatedByRandom(MathHelper.TwoPi)*8f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White*((255-Projectile.alpha)/255f);

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