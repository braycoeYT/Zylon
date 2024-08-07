using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebPhaseShot : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 46;
			Projectile.height = 46;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 7) * 60);
        }
        public override void AI() {
			Projectile.scale = 1f + Projectile.ai[0];
			Projectile.alpha -= 20;
			if (Projectile.alpha < 180) Projectile.hostile = true;
            NPC owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			if (!owner.active || owner.life < 1) Projectile.Kill();

			Projectile.velocity = Projectile.Center - owner.Center;
			Projectile.velocity.Normalize();

			if (Vector2.Distance(Projectile.Center, owner.Center) < 550 && Vector2.Distance(Projectile.Center, owner.Center) > 450) Projectile.velocity *= -3f;
			else Projectile.velocity *= -12f;

			if (Main.expertMode) Projectile.velocity *= 1.03f;

			if (Vector2.Distance(Projectile.Center, owner.Center) < 30) Projectile.Kill();
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.NPCHit5, Projectile.position);
        }
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < (int)(3*Projectile.scale); i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 2.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D yellowTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebPhaseShot_Yellow");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			
			float color2 = (float)Math.Sin(Main.GameUpdateCount/10f)/2f+0.5f;

			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				//color2 = (float)Math.Sin((Main.GameUpdateCount-k)/10f)/2f+0.5f;
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(texture.Width / 2f, frameHeight / 2f) + new Vector2(0f, Projectile.gfxOffY) - new Vector2(-8, 8); //+ new Vector2(-23, 23);
                Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.EntitySpriteDraw(texture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), colorAfterEffect*(1f-(Projectile.alpha/255f)), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
				Main.EntitySpriteDraw(yellowTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), colorAfterEffect*color2*(1f-(Projectile.alpha/255f)), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			}
			
			color2 = (float)Math.Sin(Main.GameUpdateCount/10f)/2f+0.5f;
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*(1f-(Projectile.alpha/255f)), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(yellowTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*color2*(1f-(Projectile.alpha/255f)), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}