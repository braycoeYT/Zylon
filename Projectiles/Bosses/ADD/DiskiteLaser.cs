using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class DiskiteLaser : ModProjectile
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Sun Ray");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = 1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
        public override void AI() {
            if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
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