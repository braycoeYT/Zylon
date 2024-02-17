using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Accessories
{
	public class MysticCometProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.width = 42;
			Projectile.height = 42;
			//AIType = 1;
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
        }
        public override void AI() {
			Projectile.rotation += 0.08f;
			Projectile.tileCollide = Projectile.Center.Y > Main.player[Projectile.owner].Center.Y - 64;
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.ManaRegeneration);
				dust.noGravity = false;
				dust.scale = 1.5f;
			}
        }
        public override void Kill(int timeLeft) {
			for (int i = 0; i < 6; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.ManaRegeneration);
				dust.noGravity = false;
				dust.scale = 2f;
			}
			if (Main.rand.NextFloat() < .25f) Item.NewItem(Projectile.GetSource_FromThis(), Projectile.getRect(), ModContent.ItemType<Items.Misc.MysticCometStar>());
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