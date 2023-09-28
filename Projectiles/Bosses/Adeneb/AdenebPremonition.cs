using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebPremonition : ModProjectile
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("How did you die from this wot");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 127;
		}
		int Timer;
		Vector2 temp;
        public override void AI() {
			if (++Projectile.frameCounter >= 15) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
            Timer++;
			if (Timer == 1) {
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				temp = Projectile.velocity;
				Projectile.velocity = Vector2.Zero;
				if ((int)Projectile.ai[0] % 2 == 0 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebPremonition2>(), 0, 0, Main.myPlayer);
            }
			if (Timer == 3) {
				if ((int)Projectile.ai[0] > 0 && Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + temp, temp, ModContent.ProjectileType<AdenebPremonition>(), 0, 0, Main.myPlayer, ((int)Projectile.ai[0] - 1));
				Projectile.velocity = Vector2.Zero;
			}
        }
        public override void PostAI() {
			for (int i = 0; i < 0; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
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