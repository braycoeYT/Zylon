using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexSporeCloud : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 5;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int Timer;
        public override void AI() {
			Timer++;
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			if (owner.ai[0] != 6f && Projectile.timeLeft > 15) Projectile.timeLeft = 15;

			if (Projectile.timeLeft < 16) Projectile.alpha += 17;
			Projectile.hostile = Projectile.alpha < 100;

			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 2) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
		}
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < 8; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ChlorophyteWeapon);
				Dust dust = Main.dust[dustIndex];
				dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*45));
				dust.scale = 1.25f;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White*((255f-Projectile.alpha)/255f);
	
		    for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(8, 8); //+ drawOrigin
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
	
		    return false;
		}
    }   
}