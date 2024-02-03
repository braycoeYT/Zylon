using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.Metelord
{
	public class MetelordFallenStar : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			//Projectile.aiStyle = 1;
			Projectile.friendly = false;
			Projectile.hostile = false;
			//AIType = 1;
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
        }
		int Timer;
        public override void AI() {
            Timer++;
			Projectile.tileCollide = Timer > 60;
        }
        public override void PostAI() {
            for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = false;
				dust.scale = 1f;
			}
        }
        public override void Kill(int timeLeft) {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = false;
				dust.scale = 1f;
			}
			Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ItemID.FallenStar);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
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