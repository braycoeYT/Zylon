using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Yoyos
{
	public class InsomniaProj : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			//Projectile.extraUpdates = 1;
		}
		int Timer;
		float rot;
		float rot2;
        public override void AI() {
			Timer++;
			rot += MathHelper.ToRadians(10f);
			rot2 -= MathHelper.ToRadians(4f);
			Lighting.AddLight(Projectile.Center, Color.CadetBlue.ToVector3() * 0.4f);
			if (Timer > 45 && Timer % 2 == 0) Projectile.velocity.Y += 1;
        }
		public override void OnSpawn(IEntitySource source) {
			//SoundEngine.PlaySound(SoundID.Item98, Projectile.position); //Forgot what the sound id was
        }
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Glass);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Yoyos/InsomniaProj");
			Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Yoyos/InsomniaProj2");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int frameHeight2 = texture2.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture2, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture2.Width, frameHeight2)), Color.White, rot2, new Vector2(texture2.Width / 2f, frameHeight2 / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, rot, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}