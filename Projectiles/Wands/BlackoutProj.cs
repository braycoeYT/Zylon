using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Wands
{
	public class BlackoutProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 22;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 30;
			Projectile.extraUpdates = 1;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.6f);
			if (Timer >= 20) hasHit = true;
			if (Projectile.timeLeft > 45) Projectile.timeLeft = 45;
        }
		bool hasHit;
        int Timer;
		public override void AI() {
			Timer++;
			if (Timer < 40) {
				Projectile.velocity *= 0.995f;
			}
			else if (Timer < 50) {
				Projectile.velocity *= 0.9f;
				if (Timer == 30-1) Projectile.velocity = Vector2.Zero;
			}
			else {
				Projectile.tileCollide = false;
				Vector2 vel = Projectile.Center.DirectionTo(Main.player[Projectile.owner].Center);
				float speed = 16f*(Timer-30)/40f;
				if (speed > 16f) speed = 16f;
				Projectile.velocity = vel*speed;

				if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) < 32f) Projectile.Kill();
			}

			Projectile.rotation += 0.05f*Projectile.velocity.Length() + 0.05f;
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			
			Projectile.tileCollide = false;
			if (Projectile.timeLeft < 30) Projectile.timeLeft = 30;
			Projectile.velocity = Vector2.Zero;
			return false;
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY); // - new Vector2(Projectile.width/2, Projectile.height/2);
                float per = ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Color colorAfterEffect = new Color((int)(color.R*per), (int)(color.G*per), (int)(color.B*per), color.A)*per;
				if (k == 0) colorAfterEffect = color;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect*((255f-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color*((255f-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}