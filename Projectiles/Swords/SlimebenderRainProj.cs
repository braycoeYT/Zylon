using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Swords
{
	public class SlimebenderRainProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public sealed override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1200;
			Projectile.extraUpdates = 1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (target.HasBuff(BuffID.Slimed)) modifiers.Defense.Flat -= 20;
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 4) * 60, false);
			if (finalMode) { finalMode = false; Projectile.timeLeft = 120; Projectile.aiStyle = -1; Timer = -130; }
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item60, Projectile.Center);
        }
        Color birthColor;
		bool init;
		float targetPos;
		int Timer;
		int maxRot = Main.rand.Next(28, 40);
		bool finalMode;

		float chaseFloat;
		float chaseFloat2;
        public override bool PreAI() {
			if (finalMode) {
				float num165 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
				float num166 = Projectile.localAI[0];
				if (num166 == 0f)
				{
					Projectile.localAI[0] = num165;
					num166 = num165;
				}
				if (Projectile.alpha > 0)
				{
					Projectile.alpha -= 25;
				}
				if (Projectile.alpha < 0)
				{
					Projectile.alpha = 0;
				}
				float num167 = Projectile.position.X;
				float num168 = Projectile.position.Y;
				float num169 = 800f;
				bool flag4 = false;
				int num170 = 0;
				if (Projectile.ai[1] == 0f)
				{
					for (int num171 = 0; num171 < 200; num171++)
					{
						if (Main.npc[num171].CanBeChasedBy(Projectile, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num171 + 1)))
						{
							float num172 = Main.npc[num171].position.X + (float)(Main.npc[num171].width / 2);
							float num173 = Main.npc[num171].position.Y + (float)(Main.npc[num171].height / 2);
							float num174 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num172) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num173);
							if (num174 < num169 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.npc[num171].position, Main.npc[num171].width, Main.npc[num171].height))
							{
								num169 = num174;
								num167 = num172;
								num168 = num173;
								flag4 = true;
								num170 = num171;
							}
						}
					}
					if (flag4)
					{
						Projectile.ai[1] = (float)(num170 + 1);
					}
					flag4 = false;
				}
				if (Projectile.ai[1] > 0f)
				{
					int num175 = (int)(Projectile.ai[1] - 1f);
					if (Main.npc[num175].active && Main.npc[num175].CanBeChasedBy(Projectile, true) && !Main.npc[num175].dontTakeDamage)
					{
						float num176 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
						float num177 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						if (Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num176) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num177) < 1000f)
						{
							flag4 = true;
							num167 = Main.npc[num175].position.X + (float)(Main.npc[num175].width / 2);
							num168 = Main.npc[num175].position.Y + (float)(Main.npc[num175].height / 2);
						}
					}
					else
					{
						Projectile.ai[1] = 0f;
					}
				}
				if (!Projectile.friendly)
				{
					flag4 = false;
				}
				if (flag4)
				{
					float arg_82C0_0 = num166;
					Vector2 vector19 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
					float num178 = num167 - vector19.X;
					float num179 = num168 - vector19.Y;
					float num180 = (float)Math.Sqrt((double)(num178 * num178 + num179 * num179));
					num180 = arg_82C0_0 / num180;
					num178 *= num180;
					num179 *= num180;
					int num181 = 8;
					Projectile.velocity.X = (Projectile.velocity.X * (float)(num181 - 1) + num178) / (float)num181;
					Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num181 - 1) + num179) / (float)num181;
				}
			}
            return !finalMode;
        }
        public override void AI() {
			Projectile.rotation += 0.1f;
			if (!init) {
				Projectile.scale = Projectile.ai[0];
				Projectile.damage = (int)(Projectile.damage*Projectile.scale);
				init = true;
				birthColor = new Color(Main.rand.Next(100, 256), Main.rand.Next(100, 256), Main.rand.Next(100, 256));
				targetPos = Projectile.position.Y + 700;
			}
			if (Projectile.Center.Y > targetPos && Timer >= 0) {
				Timer++;
				if (Timer < maxRot) {
					Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(-5)*Projectile.ai[1]);
				}
			}
			else if (Timer > 1) {
				Timer++;
				if (Timer > maxRot + 30) {
					finalMode = true;
					Projectile.aiStyle = 1;
					AIType = ProjectileID.Bullet;
					//Projectile.ai[0] = 0f;
					Projectile.ai[1] = 1f;
				}
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/SlimebenderRainProj_White");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = Projectile.oldPos.Length-1; k > 0; k--)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color; //color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*k/Projectile.oldPos.Length*Projectile.ai[0], SpriteEffects.None, 0);
            }
            //Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

			if (Projectile.ai[2] == 13f) for (int k = Projectile.oldPos.Length-1; k > 0; k--) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = birthColor * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*k/Projectile.oldPos.Length*Projectile.ai[0], SpriteEffects.None, 0);
            }

            return false;
        }
	}
}