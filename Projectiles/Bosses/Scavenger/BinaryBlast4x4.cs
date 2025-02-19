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

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class BinaryBlast4x4 : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            //target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5) * 60);
        }
		bool init;
		Vector2 realVel;
		Vector2 realPos;
		static int arrayW = 4;
		static int arrayH = 4;
		static int trailLength = 20;
		byte[,] numArray = new byte[arrayW, arrayH]; //For visuals.
        public override bool PreAI() {
			if (!init) {
				if (Projectile.velocity != Vector2.Zero) realVel = Projectile.velocity;

				for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) {
					numArray[i, j] = matrixNew();
				}

				init = true;
			}
			Projectile.velocity = Vector2.Zero;

            return true;
        }
		List<int[,,,]> trail; //x, y, timeleft, type
        public override void AI() {
            realPos += realVel;
			if (Math.Abs(realPos.X) > 16f) {
				float dir = realPos.X/Math.Abs(realPos.X);
				realPos.X -= 16f*dir;

				if (dir == -1) {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayH; k++) {
						Vector2 pos = Projectile.position + new Vector2(arrayW*16-16, 16*k);
						//Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos, Vector2.Zero, ModContent.ProjectileType<BinaryRemnant>(), 0, 0f, -1, numArray[arrayW-1, k], trailLength);
						
						//int[,,,] temp = new int[arrayW-1, k, numArray[arrayW-1, k], trailLength];
						//trail.Add(temp);
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
						Vector2 pos = Projectile.position + new Vector2(0, 16*k);
						//Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos, Vector2.Zero, ModContent.ProjectileType<BinaryRemnant>(), 0, 0f, -1, numArray[0, k], trailLength);
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

				/*foreach (int[,,,] i in trail) {
					int[,,,] temp = new int[Convert.ToInt32(i.GetValue(0).ToString()) - (int)dir, Convert.ToInt32(i.GetValue(1).ToString()), Convert.ToInt32(i.GetValue(2).ToString()), Convert.ToInt32(i.GetValue(3).ToString())];
					trail.Remove(i);
					trail.Add(temp);
				}*/
			}
			if (Math.Abs(realPos.Y) > 16f) {
				float dir = realPos.Y/Math.Abs(realPos.Y);
				realPos.Y -= 16f*dir;

				if (dir == -1) {
					//Spawn trail
					if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayW; k++) {
						Vector2 pos = Projectile.position + new Vector2(16*k, arrayH*16-16);
						//Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos, Vector2.Zero, ModContent.ProjectileType<BinaryRemnant>(), 0, 0f, -1, numArray[k, arrayH-1], trailLength);
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
						Vector2 pos = Projectile.position + new Vector2(16*k, 0);
						//Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos, Vector2.Zero, ModContent.ProjectileType<BinaryRemnant>(), 0, 0f, -1, numArray[k, 0], trailLength);
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

				/*foreach (int[,,,] i in trail) {
					int[,,,] temp = new int[Convert.ToInt32(i.GetValue(0).ToString()), Convert.ToInt32(i.GetValue(1).ToString()) - (int)dir, Convert.ToInt32(i.GetValue(2).ToString()), Convert.ToInt32(i.GetValue(3).ToString())];
					trail.Remove(i);
					trail.Add(temp);
				}*/
			}
        }
        public override void PostAI() {
            
        }
        private byte matrixNew() {
			byte num = (byte)Main.rand.Next(2);
			if (Main.rand.NextBool(10)) num = 2;
			return num;
		}
        public override void OnKill(int timeLeft) {
            if (Main.netMode != NetmodeID.MultiplayerClient) for (int k = 0; k < arrayW; k++) for (int l = 0; l < arrayH; l++) {
				Vector2 pos = Projectile.position + new Vector2(16*k, 16*l);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos, Vector2.Zero, ModContent.ProjectileType<BinaryRemnant>(), 0, 0f, -1, numArray[k, l], 20);
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Scavenger/BinaryRemnant");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			
			for (int i = 0; i < arrayH; i++) for (int j = 0; j < arrayW; j++) { //numArray[i, j]
				//Note: position doesn't start at the center.
				Vector2 sheetInsertPosition = (Projectile.position + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + new Vector2(i*16, j*16);

				int spriteSheetOffset = frameHeight * numArray[i, j];

				Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, 0f, new Vector2(texture.Width / 2f, frameHeight / 2f), 1f, effects, 0);
			}
			
			/*foreach (int[,,,] i in trail) {
				int x = Convert.ToInt32(i.GetValue(0).ToString());
				int y = Convert.ToInt32(i.GetValue(1).ToString());
				int timeLeft = Convert.ToInt32(i.GetValue(2).ToString());
				int offset = Convert.ToInt32(i.GetValue(3).ToString());

				Vector2 sheetInsertPosition = (Projectile.position + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor() + new Vector2(x*16, y*16);
				int spriteSheetOffset = frameHeight * timeLeft;

				Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((float)timeLeft/trailLength), 0f, new Vector2(texture.Width / 2f, frameHeight / 2f), 1f, effects, 0);
				
				int[,,,] temp = new int[x, y, timeLeft-1, offset];
				trail.Remove(i);
				if (timeLeft > 0) trail.Add(temp);
			}*/

			return false;
		}
	}   
}