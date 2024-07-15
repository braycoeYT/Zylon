using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexKatanaDuplicate : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 900;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int altCounter;
		float altAlpha;
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.WitheredWeapon, Main.rand.Next(2, 6)*60);
			target.AddBuff(BuffID.WitheredArmor, Main.rand.Next(5, 11)*60);
        }
		bool spin;
		bool doneSpin;
		Vector2 ringPos;
		float spinSpeed;
		float finalAlpha = 1f;
		int Timer;
		int delayTimer;
        public override void AI() {
			Timer++;
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			Player target = Main.player[owner.target];
			//If currently spinning
			/*if (spin) { //Spins while on the border, and then yeets itself at the player.

				Projectile.velocity = Vector2.Zero;
				spinSpeed += 0.01f;
				if (spinSpeed > 0.6f) spinSpeed = 0.6f;
				Projectile.rotation += spinSpeed;

				if (owner.ai[3] == 1f) {
					delayTimer--;
					if (delayTimer > 0) return;

					Timer++;

					spin = false;
					doneSpin = true;
					Projectile.velocity = Projectile.DirectionTo(ringPos)*4f;

					*//*if (Timer < 60) Projectile.velocity = Projectile.DirectionTo(target.Center)*6f;
					if (Timer == 60) {
						
					}*//*
				}
				return; //Don't allow regular code to run.
			}*/

			//If gone over the rainbow dot ring, begin spin sequence
			ringPos = new Vector2(Projectile.ai[0], Projectile.ai[1]);
			/*if (!doneSpin && (Projectile.Distance(ringPos) > 750f && Projectile.Distance(ringPos) < 850f)) { //Only the middle projectile is allowed to spin and return to avoid projectile spam.
				spin = true;
				delayTimer = (int)Projectile.ai[2];
			}*/

			//If shot outside, turn around
			//if (!doneSpin && Projectile.Distance(ringPos) > 850f) Projectile.velocity = Projectile.DirectionTo(ringPos)*Projectile.velocity.Length();

			if (Projectile.velocity.Length() < 26f && !doneSpin) Projectile.velocity *= 1.01f; //When first launched, don't speed up over 26f.
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;

			if (Projectile.timeLeft < 100) { //if (!doneSpin && Projectile.Distance(ringPos) > 1100f) {
				finalAlpha -= 0.01f;
				if (finalAlpha <= 0f) Projectile.Kill();
			}

			//Really cool animation
			if (altCounter % 2 == 0) {
				altAlpha += 0.05f;
				if (altAlpha >= 1f) altCounter++;
			}
			else {
				altAlpha -= 0.05f;
				if (altAlpha <= 0f) altCounter++;
			}
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/SaburRex/SaburRexKatanaDuplicate_Alt");
			Texture2D alt2Texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/SaburRex/SaburRexKatanaDuplicate_AltColor");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = (Projectile.oldPos[k] + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + new Vector2(6, 8); //Sorry tome man for doing this but I legitimately don't know why this isn't aligning
                Color colorAfterEffect = Main.DiscoColor*finalAlpha * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(alt2Texture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, alt2Texture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], new Vector2(alt2Texture.Width / 2f, frameHeight / 2f), Projectile.scale*1.25f, effects, 0);
            }
			Main.EntitySpriteDraw(alt2Texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Main.DiscoColor*finalAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale*1.25f, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*finalAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*altAlpha*finalAlpha, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}