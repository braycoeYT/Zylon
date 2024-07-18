using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexStarofWrath : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.DrawScreenCheckFluff[Projectile.type] = 1440;
        }
		public override void SetDefaults() {
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.aiStyle = -1;
			//Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			Projectile.netImportant = true;
		}
		int preTimer;
		Color realColor;
        public override bool PreAI() {
			preTimer++;
			if (preTimer < (int)Projectile.ai[1]) ogPos = Projectile.Center;
			else if (preTimer == (int)Projectile.ai[1]) {
				Projectile.alpha = 0;
				Projectile.velocity = new Vector2(0, 15).RotatedBy(MathHelper.ToRadians(Projectile.ai[0]*90f));
				Projectile.timeLeft = 134;
				
			}
            return preTimer > (int)Projectile.ai[1];
        }
		Vector2 ogPos;
		int totalMove;
        public override void AI() {
			totalMove += 15;
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active || owner.ai[0] != 7f) Projectile.Kill();

			if (Projectile.timeLeft < 26) Projectile.alpha += 10;
			Projectile.hostile = Projectile.alpha < 100;

			Projectile.rotation += 0.1f;
		}
        public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D trailTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/SaburRex/SaburRexStarofWrath_Trail");
			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 trailOrigin = new Vector2(trailTexture.Width * 0.5f, trailTexture.Height * 0.5f);

		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

			realColor = new Color(Main.DiscoB, Main.DiscoG, Main.DiscoR);
			Color color = realColor*((255f-Projectile.alpha)/255f);
			
			//Warning trail
			for (int i = 0; i < 67; i++) {
				Vector2 trailPos = ogPos + new Vector2(0, 30*i).RotatedBy(MathHelper.ToRadians(Projectile.ai[0]*90f)) - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
				if ((i < preTimer*2 && preTimer <= (int)Projectile.ai[1]) || (preTimer > (int)Projectile.ai[1] && totalMove < 30*i)) Main.spriteBatch.Draw(trailTexture, trailPos, null, realColor*((float)Math.Sin(preTimer/10f)/4f+0.25f), MathHelper.ToRadians(Projectile.ai[0]*90f), trailOrigin, 1f, SpriteEffects.None, 0);
			}

			//I hate making stupid mistakes and then testing vigorously to figure out it wasn't what you thought the issue was.
			//Main.NewText(preTimer + " <= " + (int)Projectile.ai[1]);

			//Epic trail
		    for (int k = 0; k < Projectile.oldPos.Length; k++) //new Color((float)Main.DiscoB*((float)k/20f), (float)Main.DiscoG*((float)k/20f), (float)Main.DiscoR*((float)k/20f))*((255f-Projectile.alpha)/255f)
			{
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width/2f, Projectile.height/2f); //+ drawOrigin
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 1f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*(1f-(float)k/30f), SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
	
		    return false;
		}
    }   
}