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
	public class ArchangelsWandProj : ModProjectile
	{
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 25;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
            Projectile.penetrate = 1;
			Projectile.tileCollide = false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.65f);
            if (Projectile.damage < 1) Projectile.damage = 1;
        }
		int Timer;
        public override void AI() {
			if (Projectile.ai[0] == 0f) { Projectile.ai[0] = 1f; Projectile.timeLeft = 40; } //Too lazy for custom item shoot code.
			if (Projectile.ai[0] == 0.25f && Timer == 0) Projectile.timeLeft = 50;
			Projectile.scale = Projectile.ai[0];
			Timer++;
			if (Timer > 7) Projectile.friendly = true;
            if (Timer > 15) Projectile.tileCollide = true;
			//Projectile.velocity *= 1.05f;
        }
        /*public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }*/
		public override void PostAI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			if (Timer < 1) return false;
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

			float newScale = (Projectile.scale+1f)/2f;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = lightColor; //Color.White*((255f-Projectile.alpha)/255f);

		    for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, newScale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), Color.White, Projectile.rotation, drawOrigin, newScale, SpriteEffects.None, 0f);

		    return false;
		}
        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}

			int cloneCount = 3;
			//if (Projectile.scale == 0.75f) cloneCount = 3;
			//else if (Projectile.scale == 0.5f) cloneCount = 4;
			if (Projectile.scale == 0.25f) cloneCount = 0;

			if (Main.myPlayer == Projectile.owner) for (int i = 0; i < cloneCount; i++) {
				Vector2 speed = Vector2.Normalize(Projectile.velocity.RotatedBy(MathHelper.PiOver2 + MathHelper.ToRadians(i*360/cloneCount)))*6f;
				int damage = (int)(Projectile.damage*0.8f);
				if (Projectile.scale == 0.5f) damage /= 3;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + speed*6, speed, Projectile.type, damage, Projectile.knockBack/2, Projectile.owner, Projectile.scale-0.25f);
			}
		}
	}   
}