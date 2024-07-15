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
	public class SaburRexServantofOcram : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			//Projectile.alpha = 255;
		}
		bool init;
		int Timer;
		float randRot = Main.rand.NextFloat(0.07f, 0.12f);
		float randRot2 = 1f;
		int mode;
		Vector2 home;
		public override void AI() { //ai0 - offset (dist from boss) | ai1 - offset (rotation around boss) | ai2 - time until stop intro ... owner ai3 is current total rotation
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			Timer++;
			Projectile.hostile = Projectile.alpha < 10;

			if (Timer == 1 && Main.rand.NextBool()) randRot2 = -1f;
			Projectile.rotation += randRot * randRot2;

			if (owner.ai[3] == 0f && !init) { //Init stops the projectiles from teleporting to sabur at the end of the attack.
				home = owner.Center;
			}
			else init = true;

			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}

			if (Timer > (int)Projectile.ai[2]) mode = 1; //Completed intro

			if (mode == 0) { //Intro
				float speed = 2f - (1f*Timer/Projectile.ai[2]); //Makes it seem to slow down as it moves.
				Projectile.Center = home - new Vector2(0, speed*(Projectile.ai[0] * Timer / Projectile.ai[2])).RotatedBy(MathHelper.ToRadians(Projectile.ai[1] + owner.ai[3]));
				Projectile.alpha = (int)(255f-255f*(Timer/Projectile.ai[2]));
			}
			else { //Rotate with boss mode
				if (owner.ai[0] == 4f) { //Attack is not done yet
					Projectile.Center = home - new Vector2(0, (int)Projectile.ai[0]).RotatedBy(MathHelper.ToRadians(Projectile.ai[1] + owner.ai[3]));
					Projectile.alpha = 0;
				}
				else { //Attack is done, please despawn
					Projectile.alpha += 17;
					if (Projectile.alpha > 254) Projectile.Kill();
				}
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = (Projectile.oldPos[k] + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + drawOrigin - new Vector2(10, 10);
                Color colorAfterEffect = Color.White * ((255f - Projectile.alpha) / 255f) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
				if (k == 0) colorAfterEffect = Color.White * ((255f - Projectile.alpha) / 255f);
                Main.spriteBatch.Draw(texture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White * ((255f - Projectile.alpha) / 255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}