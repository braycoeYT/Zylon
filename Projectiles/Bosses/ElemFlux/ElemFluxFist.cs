using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.GameContent.RGB;
using System;

namespace Zylon.Projectiles.Bosses.ElemFlux
{
	public class ElemFluxFist : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 90;
			Projectile.height = 90;
			Projectile.hostile = true;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.hide = true;
		}
		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index); //Doesn't draw connector in front of boss.
		}
		NPC owner;
		int prevAttack = -1;
		int attackTimer;
		Vector2 home;
		Player target;
        public override void AI() {
			if (Main.getGoodWorld) Projectile.scale = 1.5f;
			Projectile.netUpdate = true;
			owner = Main.npc[ZylonGlobalNPC.elemFluxBoss];
			home = owner.Center + new Vector2(0, -250).RotatedBy(MathHelper.ToRadians(Projectile.ai[0]*72));
			target = Main.player[owner.target];
			if (owner.active && owner.life > 1) Projectile.timeLeft = 2;

			Projectile.rotation += MathHelper.ToRadians(Projectile.velocity.X/1.5f);
			if (prevAttack != (int)owner.ai[0]) {
				prevAttack = (int)owner.ai[0];
				attackTimer = 0;
			}

			switch((int)owner.ai[0]) {
				case 0:
					Space();
					break;
			}
        }
		public void Space() {
			Vector2 targetPos = target.Center + new Vector2(0, -400).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount)+(MathHelper.Pi/3f*Projectile.ai[0])); //+ target.velocity*20f;
			//targetPos.X += 240f*(float)Math.Sin(Main.GameUpdateCount/150f+(MathHelper.Pi/3f*Projectile.ai[0]));
			//targetPos.Y += 240f*(float)Math.Sin(Main.GameUpdateCount/60f+(MathHelper.Pi/3f*Projectile.ai[0]));

			if (targetPos.Y < Projectile.Center.Y) Projectile.velocity.Y -= 0.5f;
			else Projectile.velocity.Y += 0.5f;

			if (targetPos.X < Projectile.Center.X) Projectile.velocity.X -= 0.5f;
			else Projectile.velocity.X += 0.5f;

			Projectile.velocity *= 0.98f;
		}
        public override void PostAI() {
            if (owner.Center.Distance(Projectile.Center) > 1000f) { //Inverted Plantera, kinda.
				Vector2 dir = owner.Center.DirectionTo(Projectile.Center)*1000f;
				Projectile.Center = owner.Center + dir;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			Vector2 elemFluxCenter = Main.npc[ZylonGlobalNPC.elemFluxBoss].Center;

			Asset<Texture2D> chainTexture = ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFistTrail");
			Asset<Texture2D> chainAltTexture = ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFistTrail_2");
			Asset<Texture2D> chainMidTexture = ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFistTrail_Mid");
			Asset<Texture2D> chainMid2Texture = ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFistTrail_Mid2");
			
			Rectangle? chainSourceRectangle = null;
			float chainHeightAdjustment = 0f;

			Vector2 chainOrigin = chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (chainTexture.Size() / 2f);
			Vector2 chainDrawPosition = Projectile.Center;
			Vector2 vectorFromProjectileToPlayerArms = elemFluxCenter.MoveTowards(chainDrawPosition, 4f) - chainDrawPosition;
			Vector2 unitVectorFromProjectileToPlayerArms = vectorFromProjectileToPlayerArms.SafeNormalize(Vector2.Zero);
			float chainSegmentLength = (chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : chainTexture.Height()) + chainHeightAdjustment;
			if (chainSegmentLength == 0)
				chainSegmentLength = 10;
			float chainRotation = unitVectorFromProjectileToPlayerArms.ToRotation() + MathHelper.PiOver2;
			int chainCount = 0;
			float chainLengthRemainingToDraw = vectorFromProjectileToPlayerArms.Length() + chainSegmentLength / 2f;

			while (chainLengthRemainingToDraw > 0f) {
				Color chainDrawColor = Lighting.GetColor((int)chainDrawPosition.X / 16, (int)(chainDrawPosition.Y / 16f));

				Main.spriteBatch.Draw(chainTexture.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, ZylonGlobalNPC.elemFluxRealMain, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(chainAltTexture.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, ZylonGlobalNPC.elemFluxRealSecond, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(chainMidTexture.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, ZylonGlobalNPC.elemFluxTransition, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
				Main.spriteBatch.Draw(chainMid2Texture.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, ZylonGlobalNPC.elemFluxTransition2, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
				chainDrawPosition += unitVectorFromProjectileToPlayerArms * chainSegmentLength;
				chainCount++;
				chainLengthRemainingToDraw -= chainSegmentLength;
			}


			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFist_2");
			Texture2D midTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFist_Mid");
			Texture2D mid2Texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/ElemFlux/ElemFluxFist_Mid2");

			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), ZylonGlobalNPC.elemFluxRealMain, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), ZylonGlobalNPC.elemFluxRealSecond, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(midTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), ZylonGlobalNPC.elemFluxTransition, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(mid2Texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), ZylonGlobalNPC.elemFluxTransition2, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}