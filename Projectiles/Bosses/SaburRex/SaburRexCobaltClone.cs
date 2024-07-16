using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexCobaltClone : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults() {
			Projectile.width = 58;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			//Projectile.hostile = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		Player target;
		int attackTimer;
		int attackNum;
		int attackNum2;
		int attackNum3;
		int attackNum4;
		int attackNum5;
		int attackNum6;
		int attackNum7;
		int attackNum8;
		float attackFloat;
		float attackFloat2;
		float attackFloat3;
		float attackFloat4;
		bool death;
		float idkWhat;
		float oldway;
        public override bool PreAI() {
			Projectile.ai[1] = Projectile.alpha;
			if (death) { Projectile.alpha += 15; if (Projectile.alpha > 254) Projectile.Kill(); }
            return !death;
        }
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			float hpLeft = (float)owner.life/(float)owner.lifeMax;

			if (Projectile.alpha > 100) Projectile.alpha -= 10;

			Projectile.hostile = Projectile.alpha < 101;

			target = Main.player[(int)Projectile.ai[0]];
            if (attackTimer == 0) {
                if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexCobaltSwordClone>(), Projectile.damage, 0f, -1, Projectile.whoAmI);
            }

			//Actual movement.
			attackTimer++;
			if (attackNum == 0) {
				Projectile.velocity *= 0.93f;
				if (attackTimer == 1) { //Random color to draw the arrows in.
					attackNum3 = Main.rand.Next(127, 256);
					attackNum4 = Main.rand.Next(127, 256);
					attackNum5 = Main.rand.Next(127, 256);
				}

				if (Projectile.DirectionTo(target.Center).X > 0) Projectile.direction = 1;
				else Projectile.direction = -1;
				Projectile.spriteDirection = Projectile.direction;

				if (Projectile.direction == 1) oldway = Projectile.DirectionTo(target.Center).ToRotation() + MathHelper.PiOver2;
				else oldway = -1*Projectile.DirectionTo(target.Center).ToRotation() - MathHelper.PiOver2;

				if (attackNum2 < 21 && attackTimer % 2 == 0) attackNum2++; //Length of arrow trail. 21 tells the drawer that it's done.

				if (attackTimer > 90) { attackNum = 1; attackTimer = 0; }

				attackFloat2 = Projectile.Center.X;
				attackFloat3 = Projectile.Center.Y;
				attackFloat4 = Projectile.ai[2];
				attackNum8 = Projectile.direction;

				idkWhat = Projectile.Center.AngleTo(target.Center);
				Projectile.ai[2] = idkWhat;

				/*if (Math.Abs(Projectile.velocity.X) > 0.05f) {
					if (Projectile.velocity.X < 0) Projectile.direction = -1;
					else Projectile.direction = 1;
				}*/
			}
			else if (attackNum == 1) {
				if (attackTimer == 1) {
					//float rot = Projectile.ai[2] + MathHelper.Pi;
					//if (Projectile.direction == -1) rot = -Projectile.ai[2] + MathHelper.Pi;
					Projectile.velocity = new Vector2(0, 24f).RotatedBy(Projectile.ai[2]-MathHelper.PiOver2);
					SoundEngine.PlaySound(SoundID.Item1, Projectile.Center);
				}
				else Projectile.velocity *= 0.975f;
				attackFloat += Projectile.velocity.Length();
				attackNum6 = (int)(attackFloat/36f)+1;
				if (attackNum6 > 22) {
					attackTimer = 0;
					attackFloat = 0f;
					attackNum = 0;
					attackNum2 = 0;
					attackNum6 = 0;

					death = true;
				}
			}

			//Animation plz work
			if (oldway >= MathHelper.ToRadians(270) && oldway < MathHelper.ToRadians(325)) Projectile.frame = 1; //Hand top left

			if (oldway >= MathHelper.ToRadians(325) || oldway < MathHelper.ToRadians(30)) Projectile.frame = 2; //Hand straight up

			if (oldway >= MathHelper.ToRadians(30) && oldway < MathHelper.ToRadians(75)) Projectile.frame = 3; //Hand top right

			if (oldway >= MathHelper.ToRadians(75) && oldway < MathHelper.ToRadians(115)) Projectile.frame = 4; //Hand right

			if (oldway >= MathHelper.ToRadians(115) && oldway < MathHelper.ToRadians(180)) Projectile.frame = 5; //Hand down right

			if (oldway < -MathHelper.Pi) Projectile.frame = 5;

			//Main.NewText(oldway);
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D greyArrowTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/NPCs/Bosses/SaburRex/SaburRex_GreyArrow");

			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);
			Vector2 GAOrigin = new Vector2(greyArrowTexture.Width / 2f, greyArrowTexture.Height / 2f);

			int total = attackNum2;
			if (attackNum2 == 21) total = 20;
			for (int i = 0; i < total; i++) {
				Color col = new Color(attackNum3, attackNum4, attackNum5);

				float shade = 1f;
				if (i+1 == attackNum2) shade = (float)(attackTimer%2)/2f;

				//float rot = attackFloat4 + MathHelper.Pi;
				//if (attackNum8 == -1) rot = -attackFloat4 + MathHelper.Pi;

				float rot = attackNum8*attackFloat4 + MathHelper.Pi;

				int dir = 1;
				if (rot < MathHelper.Pi || rot > MathHelper.TwoPi) dir = -1;
				//Main.NewText(rot);
				
				Vector2 newPos = (new Vector2(attackFloat2, attackFloat3) + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() - new Vector2(0, 36*i).RotatedBy(idkWhat+MathHelper.PiOver2);

				if (i >= attackNum6) Main.EntitySpriteDraw(greyArrowTexture, newPos, null, col*shade, idkWhat-MathHelper.PiOver2, GAOrigin, 1.5f, SpriteEffects.None, 0);
			}

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*(1f-(float)Projectile.alpha/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}