using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Guns
{
	public class Gunball_Proj : ModProjectile
	{
        public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			Projectile.scale = 0.75f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (!target.boss && target.type != NPCID.GolemHead && target.type != NPCID.SkeletronHand) {
				if (colorBall == 0) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballRed>(), Main.rand.Next(4, 8)*60);
				else if (colorBall == 1) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballBlue>(), Main.rand.Next(4, 8)*60);
				else target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballGreen>(), Main.rand.Next(4, 8)*60);
			}
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				if (colorBall == 0) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballRed>(), Main.rand.Next(4, 8)*60);
				else if (colorBall == 1) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballBlue>(), Main.rand.Next(4, 8)*60);
				else target.AddBuff(ModContent.BuffType<Buffs.Debuffs.GunballGreen>(), Main.rand.Next(4, 8)*60);
			}
        }
		int colorBall;
		int track;
		int delay;
		bool init;
        public override void AI() {
			if (!init) {
				colorBall = Main.rand.Next(3);
				track = Main.rand.Next(2);
				init = true;

				if (Projectile.ai[0] > 0f) {
					colorBall = (int)(Projectile.ai[0] - 1f);
					Projectile.ai[0] = 0f;
					delay = 20;
				}
			}
            Projectile.rotation += 0.1f;

			if (delay > 0) { //invincibility
				Projectile.penetrate = 2;
				delay--;

				if (delay == 0) Projectile.penetrate = 1;
				return;
			}

			if (track == 1) {
				Projectile.aiStyle = 1;
				AIType = ProjectileID.Bullet;
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
				float num169 = 300f;
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
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.Red;
            if (colorBall == 1f) color = Color.Blue;
            else if (colorBall == 2f) color = Color.Green;

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k / 8f)) + Projectile.scale;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}