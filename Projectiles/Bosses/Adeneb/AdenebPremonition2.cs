using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebPremonition2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("How did you die from this wot");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 4;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 59;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 127;
			Projectile.frameCounter = 1;
		}
        public override void AI() {
			if (++Projectile.frameCounter >= 15) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}