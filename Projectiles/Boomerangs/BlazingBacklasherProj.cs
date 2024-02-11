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
	public class BlazingBacklasherProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 5;
        }
		public override void SetDefaults() {
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Daybreak, 60*Main.rand.Next(3, 6));
        }
        int Timer;
        public override void AI() {
            Timer++;
			if (Timer > 45) {
				Projectile.frame += 1;
				if (Projectile.frame > 4) { Projectile.Kill(); Projectile.frame = 4; }
            }
			else if (Timer == 45) { Projectile.alpha = 0; SoundEngine.PlaySound(SoundID.Item14, Projectile.Center); Projectile.friendly = true; }
        }
        public override void PostAI() {
			if (Main.rand.NextBool() && Projectile.alpha == 0) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			if (Projectile.alpha != 0) return false;
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