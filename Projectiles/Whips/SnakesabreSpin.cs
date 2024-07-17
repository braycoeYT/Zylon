using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Whips
{
	public class SnakesabreSpin : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.alpha = 255;
			Projectile.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
			Projectile.tileCollide = false;
		}
		Player main;
		int Timer;
		int Timer2;
		Vector2 oops;
		int fixer;
		NPC target = Main.npc[Main.maxNPCs];
        public override void AI() {
			if (Timer2 < Projectile.ai[0]) {
				Timer2++;
				return;
            }
			Timer++;
			main = Main.player[Projectile.owner];
			//Projectile.friendly = Timer > 52;
			if (Timer == 1) {
				//SoundEngine.PlaySound(SoundID.Item109, Projectile.Center);
				Projectile.Center = main.Center + new Vector2(0, 80).RotatedByRandom(MathHelper.TwoPi);
					float distanceFromTarget = 250f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false; //between < 100f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							target = Main.npc[i];
						}
					}
				}
				if (Main.npc[Main.player[Projectile.owner].MinionAttackTargetNPC].active) {
					targetCenter = Main.npc[Main.player[Projectile.owner].MinionAttackTargetNPC].Center;
					foundTarget = true;
					target = Main.npc[Main.player[Projectile.owner].MinionAttackTargetNPC];
				}
			}
			if (!foundTarget || !target.active) oops = Vector2.Normalize(main.Center - Projectile.Center) * 20f;
			else oops = Vector2.Normalize(targetCenter - Projectile.Center) * 20f;
			Projectile.rotation = oops.ToRotation();
            }
			else if (Timer <= 52) {
				Projectile.alpha -= 5;
				Projectile.rotation += MathHelper.ToRadians(1.41176470588f*(52-Timer));
            }
			else if (Timer == 53) {
				Projectile.velocity = oops;
				Projectile.rotation = Projectile.velocity.ToRotation();
            }
			else if (Timer == 233) {
				Projectile.Kill();
			}

			if (Timer > 217) Projectile.alpha -= 15;

			if (Timer > 53 && Timer < 80) fixer++;
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height - fixer);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White*((255f-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width*0.5f, Projectile.height*0.5f);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.6f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}