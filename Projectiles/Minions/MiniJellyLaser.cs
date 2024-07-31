using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Threading;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Minions
{
	public class MiniJellyLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.height = 20;
			Projectile.width = 20;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 150;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Summon;
		}
		int Timer;
		float speed = 1f;
		float save;
		Vector2 vel;
		bool found;
		public override void AI() {
			Timer++;
			Projectile.tileCollide = Timer > 30;
			Lighting.AddLight(Projectile.Center, Color.LimeGreen.ToVector3() * 0.7f);
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			
			if (Timer == 1) save = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Timer < 20) Projectile.velocity *= 0.92f;
			else {
				if (Timer % 5 == 0 && (Timer < 60 || !found) && Main.npc[(int)Projectile.ai[0]].active) {
					vel = Projectile.Center.DirectionTo(Main.npc[(int)Projectile.ai[0]].Center);
					found = true;
				}
				if (!found) Projectile.rotation = save; //Look cooler plz when no target
				//else if (Timer % 5 == 0 && )
				if (speed < 13f && found) speed *= 1.15f;
				Projectile.velocity = vel*speed;
				Projectile.tileCollide = !Main.npc[(int)Projectile.ai[0]].active;
			}

			if (!found && Main.npc[(int)Projectile.ai[0]].active) {
				float distanceFromTarget = 600f;
				Vector2 targetCenter = Projectile.position;
				bool foundTarget = false;

				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							Projectile.ai[0] = i;
						}
					}
				}
			}
		}
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JadeDust2>());
				Dust dust = Main.dust[dustIndex];
				dust.velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(15));
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}
}