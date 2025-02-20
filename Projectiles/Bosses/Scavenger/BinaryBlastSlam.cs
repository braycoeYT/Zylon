using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using System.Collections.Generic;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class BinaryBlastSlam : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenCode>(), Main.rand.Next(3, 7) * 60);
        }
		bool init;
		Vector2 realVel;
		Vector2 realPos;
		static int arrayW = 8;
		static int arrayH = 8;
		static int trailLength = 20;
		byte[,] numArray = new byte[arrayW, arrayH]; //For visuals.
		bool end;
		int endTimer;
        public override bool PreAI() {
			if (!init) {
				if (Projectile.velocity != Vector2.Zero) realVel = Projectile.velocity;

				for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) {
					numArray[i, j] = matrixNew();
				}
				
				trail.Add([0, 0, 0, 0]);

				init = true;
			}
			Projectile.velocity = Vector2.Zero;

			if (end) {
				if (endTimer == 0) {
					for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) {
						int[] temp = {i, j, trailLength, numArray[i, j]}; //Creates a vanishing thing at each point.
						trail.Add(temp);
						numArray[i, j] = 2; //Makes the original invisible.
					}
				}
				endTimer++;
				Projectile.hostile = false;
				realVel = Vector2.Zero;

				if (endTimer > 20) Projectile.active = false;
			}

            return !end;
        }
		List<int[]> trail = new List<int[]>(); //x, y, timeleft, type
		int Timer;
        public override void AI() {
			Timer++;

			if (Timer < 50) {
				realVel = Main.npc[ZylonGlobalNPC.scavengerBoss].velocity;
			}

			if (Projectile.timeLeft == 21) end = true;

            realPos += realVel;
			if (Math.Abs(realPos.X) > 16f) {
				float dir = realPos.X/Math.Abs(realPos.X);
				realPos.X -= 16f*dir;

				if (dir == -1) {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayH; k++) {
						int[] temp = { arrayW-1, k, trailLength, numArray[arrayW-1, k]};
						trail.Add(temp);
					}

					//Determine new numbers
					for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) {
						if (arrayW-2-i == -1) { //Choose new number
							numArray[arrayW-1-i, j] = matrixNew();
						}
						else { //Change to prev number
							numArray[arrayW-1-i, j] = numArray[arrayW-2-i, j];
						}
					}
				}
				else {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayH; k++) {
						int[] temp = { 0, k, trailLength, numArray[0, k]};
						trail.Add(temp);
					}

					//Determine new numbers
					for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) {
						if (i+1 == arrayW) { //Choose new number
							numArray[i, j] = matrixNew();
						}
						else { //Change to prev number
							numArray[i, j] = numArray[i+1, j];
						}
					}
				}

				Projectile.position.X += 16*dir;

				for (int i = 0; i < trail.Count; i++) {
					int[] temp = trail[i];
					int x = (int)temp.GetValue(0);
					int y = (int)temp.GetValue(1);
					int timeLeft = (int)temp.GetValue(2);
					int offset = (int)temp.GetValue(3);

					int[] tempNew = { x-(int)dir, y, timeLeft, offset };
					trail[i] = tempNew;
				}
			}
			if (Math.Abs(realPos.Y) > 16f) {
				float dir = realPos.Y/Math.Abs(realPos.Y);
				realPos.Y -= 16f*dir;

				if (dir == -1) {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayW; k++) {
						int[] temp = { k, arrayH-1, trailLength, numArray[k, arrayH-1]};
						trail.Add(temp);
					}

					//Determine new numbers
					for (int i = 0; i < arrayW; i++) for (int j = 0; j < arrayH; j++) {
						if (arrayH-2-i == -1) { //Choose new number
							numArray[j, arrayH-1-i] = matrixNew();
						}
						else { //Change to prev number
							numArray[j, arrayH-1-i] = numArray[j, arrayH-2-i];
						}
					}
				}
				else {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayW; k++) {
						int[] temp = { k, 0, trailLength, numArray[k, 0]};
						trail.Add(temp);
					}

					//Determine new numbers
					for (int i = 0; i < arrayW; i++) for (int j = 0; j < arrayH; j++) {
						if (i+1 == arrayH) { //Choose new number
							numArray[j, i] = matrixNew();
						}
						else { //Change to prev number
							numArray[j, i] = numArray[j, i+1];
						}
					}
				}

				Projectile.position.Y += 16*dir;

				for (int i = 0; i < trail.Count; i++) {
					int[] temp = trail[i];
					int x = (int)temp.GetValue(0);
					int y = (int)temp.GetValue(1);
					int timeLeft = (int)temp.GetValue(2);
					int offset = (int)temp.GetValue(3);

					int[] tempNew = { x, y-(int)dir, timeLeft, offset };
					trail[i] = tempNew;
				}
			}
        }
        private byte matrixNew() {
			byte num = (byte)Main.rand.Next(2);
			if (Main.rand.NextBool(10)) num = 2;
			return num;
		}
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Scavenger/Binary");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			
			for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) { //numArray[i, j]
				//Note: position doesn't start at the center.
				Vector2 sheetInsertPosition = (Projectile.position + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + new Vector2(i*16, j*16);

				int spriteSheetOffset = frameHeight * numArray[i, j];

				Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, 0f, new Vector2(texture.Width / 2f, frameHeight / 2f), 1f, effects, 0);
			}
			
			for (int i = 0; i < trail.Count; i++) {
				int[] temp = trail[i];
				int x = (int)temp.GetValue(0);
				int y = (int)temp.GetValue(1);
				int timeLeft = (int)temp.GetValue(2);
				int offset = (int)temp.GetValue(3);

				Vector2 sheetInsertPosition = (Projectile.position + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + new Vector2(x*16, y*16);
				int spriteSheetOffset = frameHeight * offset;
				Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((float)timeLeft/trailLength), 0f, new Vector2(texture.Width / 2f, frameHeight / 2f), 1f, effects, 0);
				
				int[] temp2 = { x, y, timeLeft-1, offset };
				if (timeLeft > 1) trail[i] = temp2;
				else trail.RemoveAt(i);
			}

			return false;
		}
	}   
}