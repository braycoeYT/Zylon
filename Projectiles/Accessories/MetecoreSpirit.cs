using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Accessories
{
	public class MetecoreSpirit : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.tileCollide = false;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 60;
		}
		int Timer;
        public override void AI() {
			Timer++;
            Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.metelordExpert == true) Projectile.timeLeft = 2;
			Vector2 targetPos = player.Center - new Vector2(0, 60);

			float add = (float)Timer / 60;
			if (add > 10f) add = 10f;

			Projectile.velocity = Vector2.Normalize(Projectile.Center - targetPos);
			Projectile.velocity *= -8f - add;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Vector2.Distance(Projectile.Center, targetPos) < 32) {
				p.metecoreFloat += 0.04f;
				Projectile.Kill();
            }
			if (p.metecoreFloat >= 3f) {
				Projectile.alpha += 10;
				if (Projectile.alpha >= 255) Projectile.Kill();
            }
			else Projectile.alpha -= 10;
			if (Projectile.alpha < 0) Projectile.alpha = 0;
			if (Projectile.alpha > 255) Projectile.alpha = 255; //TRANSITION POWER!!!!!!!!!!!!!!

			float lm = Projectile.alpha/255;
			Lighting.AddLight(Projectile.Center, 0.2f*lm, 0.1f*lm, 0.05f*lm);
        }
		public override bool PreDraw(ref Color lightColor) {
			if (Projectile.alpha > 0) return true;
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
        public override void Kill(int timeLeft) {
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
        }
    }
}