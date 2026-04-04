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
	public class FatalErrorProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 90;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
		}
		int Timer;
		float transition;
        public override void AI() {
			Projectile.velocity *= 0.98f;
			Projectile.rotation += Projectile.velocity.Length()*0.015f;

			Timer++;
			if (Timer == 1) Projectile.rotation += MathHelper.ToRadians(45);
			if (Timer > 29) transition += 0.04f;
			if (transition > 1f) transition = 1f;

			Lighting.AddLight(Projectile.Center, Color.Lime.ToVector3() * 0.4f * (1f-transition));
			Lighting.AddLight(Projectile.Center, Color.Red.ToVector3() * 0.4f * transition);
        }
        public override void OnKill(int timeLeft) {
			if (timeLeft == 0) Projectile.rotation = 0f;

			SoundEngine.PlaySound(SoundID.Item9.WithPitchOffset(-1f));
			if (Main.myPlayer == Projectile.owner) { //I hope Piskel isn't lying to me.
				//Horizontal
				for (int i = 0; i < 3; i++) {
					Vector2 offset = new Vector2(-24, -32) + new Vector2(8 + i*16, 0);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + offset.RotatedBy(Projectile.rotation), Vector2.Zero, ModContent.ProjectileType<FatalErrorProj2>(), Projectile.damage/3, Projectile.knockBack/3f, Projectile.owner, transition, Projectile.rotation);
				}
				for (int i = 0; i < 3; i++) {
					Vector2 offset = new Vector2(-24, -32) + new Vector2(8 + i*16, 64);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + offset.RotatedBy(Projectile.rotation), Vector2.Zero, ModContent.ProjectileType<FatalErrorProj2>(), Projectile.damage/3, Projectile.knockBack/3f, Projectile.owner, transition, Projectile.rotation);
				}
				//Vertical
				for (int i = 0; i < 3; i++) {
					Vector2 offset = new Vector2(-24, -32) + new Vector2(0, 16 + i*16);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + offset.RotatedBy(Projectile.rotation), Vector2.Zero, ModContent.ProjectileType<FatalErrorProj2>(), Projectile.damage/3, Projectile.knockBack/3f, Projectile.owner, transition, Projectile.rotation);
				}
				for (int i = 0; i < 3; i++) {
					Vector2 offset = new Vector2(-24, -32) + new Vector2(48, 16 + i*16);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + offset.RotatedBy(Projectile.rotation), Vector2.Zero, ModContent.ProjectileType<FatalErrorProj2>(), Projectile.damage/3, Projectile.knockBack/3f, Projectile.owner, transition, Projectile.rotation);
				}
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D red = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/FatalErrorProj_Red");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(red, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*transition, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}