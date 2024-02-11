using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Boomerangs
{
	public class Mecharang : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.light = 0.3f;
		}
		int Timer;
		bool off;
		bool resetTime;
		public override void AI() {
			if (off) {
				Projectile.ai[0] = 1f;
				Projectile.frame = 1;
				Projectile.aiStyle = 1;
				AIType = ProjectileID.Grenade;
				Projectile.width = 20;
				Projectile.height = 20;
				if (!resetTime) {
					Projectile.timeLeft = 180;
					resetTime = true;
					offRot = Projectile.rotation;
                }

				Projectile.velocity.X *= 0.95f;
				if (Timer % 3 == 0) Projectile.velocity.Y += 1;

				if (Projectile.timeLeft == 1) {
					Projectile.width = 60;
					Projectile.height = 60;
                }
            }

			Timer++;
			if (!off) Projectile.rotation += 0.15f;
			if (Timer >= 50) off = true;
			else if (Timer >= 35 && !off) Projectile.velocity *= 0.95f;
		}
		float offRot;
        public override void PostAI() {
			if (!off) return;

			//How rotation is handled in off mode.
            offRot += MathHelper.ToRadians(Projectile.velocity.X*3);
			Projectile.rotation = offRot;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			resetTime = true;
			Projectile.timeLeft = 2;
            off = true;
			offRot = Projectile.rotation;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity.Y *= 0.4f; //Important note: use 0.8 for a funny effect

			off = true;
			return false;
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D textureBase = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/Mecharang");
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/Mecharang_Glow");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			if (Projectile.timeLeft < 2) return false;
			Main.EntitySpriteDraw(textureBase, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
            return false;
        }
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 20; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
		}
    }   
}