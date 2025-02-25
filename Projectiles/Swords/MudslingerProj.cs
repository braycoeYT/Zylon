using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Swords
{
	public class MudslingerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mudslinger");
			Main.projFrames[Projectile.type] = 6;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 3;
		}
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            modifiers.SourceDamage *= (0.5f + (0.5f * pwr));
        }
        int Timer;
		float pwr;
		public override void AI() {
			pwr += 0.03f;
			if (Main.player[Projectile.owner].ZoneMeteor || Main.player[Projectile.owner].ZoneUnderworldHeight) pwr += 0.01f;
			else if (Main.player[Projectile.owner].ZoneDesert) pwr += 0.005f;
			else if (Main.player[Projectile.owner].ZoneJungle || Main.player[Projectile.owner].ZoneBeach) pwr -= 0.005f;
			else if (Main.player[Projectile.owner].ZoneSnow || Main.player[Projectile.owner].ZoneSkyHeight || Main.player[Projectile.owner].ZoneNormalSpace) pwr -= 0.01f;
			if (pwr > 1) pwr = 1;
			Projectile.velocity.Normalize();
			Projectile.velocity *= (float)Math.Pow(6f, pwr)/0.75f+2f;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(Projectile.Center, 0.75f*pwr, 0f, 0f);
			if (pwr >= 1) {
				Timer++;
				if (Timer > 29 || Main.player[Projectile.owner].ZoneMeteor || Main.player[Projectile.owner].ZoneUnderworldHeight) {
					if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 5; x++) Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, Projectile.velocity.RotatedByRandom(MathHelper.PiOver4/2), ModContent.ProjectileType<MudslingerProj_3>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
					Projectile.Kill();
                }
            }
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextFloat(0.75f) < pwr) {
				target.AddBuff(BuffID.OnFire, (int)(Main.rand.Next(8, 10)*60*pwr));
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				if (Main.rand.NextFloat(0.75f) < pwr)
				{
					target.AddBuff(BuffID.OnFire, (int)(Main.rand.Next(8, 10) * 60 * pwr));
				}
			}
        }

        public override void PostAI() {
			if (pwr < 0.3f) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (pwr < 0.6f) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/MudslingerProj_2");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*pwr*0.75f, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}