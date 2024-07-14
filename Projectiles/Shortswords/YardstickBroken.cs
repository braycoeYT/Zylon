using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Shortswords
{
	public class YardstickBroken : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 360;
			Projectile.penetrate = 6;
			Projectile.friendly = true;
		}
        public override void AI() {
			Projectile.rotation += Projectile.velocity.X*0.1f;
			Projectile.velocity.X *= 0.984f;
			Projectile.velocity.Y -= 0.1f;
			if (Projectile.velocity.Y < 8f) Projectile.velocity.Y = 8f;

			Projectile.frame = (int)Projectile.ai[0];
            if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			Projectile.velocity.Y = 0f;
			return false;
        }
        public override void OnKill(int timeLeft) {
            if (timeLeft > 0) for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture);
				dust.noGravity = true;
				dust.scale = 1.25f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}