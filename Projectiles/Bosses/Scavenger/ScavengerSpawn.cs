using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class ScavengerSpawn : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 130;
			Projectile.height = 162;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 30;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			//Projectile.alpha = 255;
		}
		float offset;
        public override void AI() { //ai0 = attack ID, ai1 = special data
			NPC owner = Main.npc[ZylonGlobalNPC.scavengerBoss];
			Projectile.frame = (int)owner.ai[1];

			offset = 1f-(float)(Math.Pow(2, (30f-Projectile.timeLeft)/11.61f)-1f)/5f; //(30f-Projectile.timeLeft)/30f;//(float)Math.Sin(MathHelper.Pi*(Projectile.timeLeft)/60f);

			if (Projectile.ai[0] == 0f) { //Quarter step
				Projectile.Center = Main.player[owner.target].Center - new Vector2(0, 360).RotatedBy(Projectile.ai[1]);
			}
			else if (Projectile.ai[0] == 1f) { //Big numbers
				Projectile.Center = new Vector2(Projectile.ai[1], Projectile.ai[2]);
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Scavenger/Scavenger");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition + new Vector2(100*offset, 0).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount)), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((30f-Projectile.timeLeft)/50f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition - new Vector2(100*offset, 0).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount)), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((30f-Projectile.timeLeft)/50f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition + new Vector2(0, 100*offset).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount)), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((30f-Projectile.timeLeft)/50f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition - new Vector2(0, 100*offset).RotatedBy(MathHelper.ToRadians(Main.GameUpdateCount)), new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((30f-Projectile.timeLeft)/50f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
    }   
}