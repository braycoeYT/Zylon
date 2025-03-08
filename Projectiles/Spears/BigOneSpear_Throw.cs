using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class BigOneSpear_Throw : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.scale = 1.2f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.8f);
			if (Projectile.damage < 1) Projectile.damage = 1;
        }
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 15 == 0 && Main.myPlayer == Projectile.owner) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity*-0.5f, ModContent.ProjectileType<BigOneSpear_1x1>(), Projectile.damage*3/4, 0f, Projectile.owner);
			}
        }
        public override void PostAI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }
        public override void OnKill(int timeLeft) {
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