using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;

namespace Zylon.Projectiles.Tomes
{
	public class StairwaytoHeavenProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = Main.rand.Next(60, 181);
			Projectile.penetrate = 1;
			Projectile.extraUpdates = 2;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(Projectile.Center, Color.Yellow.ToVector3() * 0.4f);
        }
        public override void PostAI() {
            for (int i = 0; i < 1; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = true;
				dust.scale = 1.2f;
			}
        }
		public override bool OnTileCollide(Vector2 oldVelocity) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			return true;
		}
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = true;
				dust.scale = 2f;
			}
			float ignoreThis = 0f;
			if (Projectile.penetrate == 0) ignoreThis = 1f;
			if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 2; i++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(-15 + i*30)), ModContent.ProjectileType<StairwaytoHeavenProj_2>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/2f, Projectile.owner, ignoreThis);
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