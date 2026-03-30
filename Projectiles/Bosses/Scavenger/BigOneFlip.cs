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

namespace Zylon.Projectiles.Bosses.Scavenger
{
	public class BigOneFlip : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenCode>(), Main.rand.Next(3, 7) * 60);
        }
		int Timer;
		int mode;
		int xOffset = Main.rand.Next(-120, 121);
        public override void AI() { //ai0 = hp of boss left as a decimal
			NPC owner = Main.npc[ZylonGlobalNPC.scavengerBoss];
			if (!owner.active || owner.life < 1) Projectile.Kill();

			if (Projectile.timeLeft < 20) {
				Projectile.scale = Projectile.timeLeft/20f;
				Projectile.hostile = false;
				return;
			}
			Vector2 targetCenter = Main.player[Main.npc[ZylonGlobalNPC.scavengerBoss].target].Center + new Vector2(xOffset + Main.player[Main.npc[ZylonGlobalNPC.scavengerBoss].target].velocity.X*10, 0);

			Timer++;
			if (Timer < 15 && mode == 0) {
				Projectile.rotation = MathHelper.Pi;
				Projectile.scale = Timer/15f;
				if (Projectile.scale > 1f) Projectile.scale = 1f;
				Projectile.velocity *= 0.95f;
			}
			else if (mode == 0) {
				Projectile.velocity.Y += 0.25f + 0.25f*Projectile.ai[0];
				if (Projectile.velocity.Y > 13f) Projectile.velocity.Y = 13f;
				if (Projectile.Center.Y > targetCenter.Y + 460) {
					mode = 1;
					Timer = 0;
				}
			}
			else if (mode == 1) {
				Projectile.position.Y = targetCenter.Y + 460 - Projectile.height/2;
				Projectile.rotation += MathHelper.ToRadians(15); //Do a barrel roll.

				if (Math.Abs(Projectile.Center.X - targetCenter.X) < 16*8) Projectile.velocity *= 0.92f;
				else if (Projectile.Center.X < targetCenter.X) Projectile.velocity.X += 1.5f - 0.5f*Projectile.ai[0];
				else Projectile.velocity.X -= 1.5f - 0.5f*Projectile.ai[0];

				if (Timer >= 60) {
					mode = 2;
					Projectile.timeLeft = 180;
				}
			}
			else if (mode == 2) {
				Projectile.velocity = new Vector2(0, -9);
			}

			if (owner.ai[0] != 4f && Projectile.timeLeft > 20) Projectile.timeLeft = 20;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}