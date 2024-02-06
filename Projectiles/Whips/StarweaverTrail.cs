using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Whips
{
	public class StarweaverTrail : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 15;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.alpha = 0;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.damage = (int)(Projectile.damage * 0.65f);
		}
		int Timer;
		float fakeScale;
		float fakeRot = MathHelper.ToRadians(-150);
        public override void AI() {
			Timer++;
			if (Timer > 45) {
				fakeScale -= 0.1f;
				fakeRot += MathHelper.ToRadians(5);
            }
			else if (Timer > 30){
				fakeScale += 0.1f;
				fakeRot += MathHelper.ToRadians(5);
            }
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Whips/StarweaverTrail");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, fakeRot, new Vector2(texture.Width / 2f, frameHeight / 2f), fakeScale, effects, 0);
			return false;
		}
	}   
}