using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;
using System;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebFinaleSunRing : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 9) * 60);
        }
		float totalSpin;
		float spin = 6.5f;
		bool init;
		Vector2 startPos;
        public override void AI() {
			if (!init) {
				startPos = Projectile.Center;
				init = true;
            }
			Projectile.alpha -= 20;
			if (Projectile.alpha < 180) Projectile.hostile = true;
			NPC owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			if (!owner.active || owner.life < 1) Projectile.Kill();
            Projectile.ai[1] += 1f;
			Projectile.velocity = Vector2.Zero;
			float newpos = 800-Projectile.ai[1]*6;
			if (newpos < 1) Projectile.Kill();
			spin -= 0.1f;
			if (spin < 0f) spin = 0f;
			totalSpin += spin;
			Projectile.Center = startPos + new Vector2(0, newpos).RotatedBy(MathHelper.ToRadians(totalSpin+Projectile.ai[0])); //og is x0.5

        }
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < 3; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 3f + Main.rand.Next(-30, 31) * 0.01f;
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