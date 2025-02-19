using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class BinaryRemnant : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		bool init;
		public override bool PreAI() {
			if (!init) { Projectile.timeLeft = (int)Projectile.ai[1]; init = true; }
			if (Projectile.ai[0] == 2f) Projectile.Kill();
			Projectile.velocity = Vector2.Zero;
            return true;
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Scavenger/BinaryRemnant");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			int spriteSheetOffset = frameHeight * (int)Projectile.ai[0];

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*(Projectile.timeLeft/Projectile.ai[1]), 0f, new Vector2(texture.Width / 2f, frameHeight / 2f), 1f, effects, 0);
			
			return false;
		}
	}   
}