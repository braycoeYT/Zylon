using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class HeartbreakerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
        }
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.timeLeft = 120;
			Projectile.penetrate = 3;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
		}
		int Timer;
		public override void AI() { //ai0 = projectile target
			Timer++;

			if (Timer < 60) {
				bool foundTarget = false;
			    if (!Main.npc[(int)Projectile.ai[0]].active) {
					float distanceFromTarget = 200f;
					Vector2 targetCenter = Projectile.position;
						
					for (int i = 0; i < Main.maxNPCs; i++) {
						NPC npc = Main.npc[i];

						if (npc.CanBeChasedBy()) {
							float between = Vector2.Distance(npc.Center, Projectile.Center);
							bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
							bool closeThroughWall = distanceFromTarget < 100f;
	
							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
								Projectile.ai[0] = i;
							}
						}
					}
				}
			    else foundTarget = true;

				if (foundTarget) Projectile.rotation = Projectile.Center.DirectionTo(Main.npc[(int)Projectile.ai[0]].Center).ToRotation() + MathHelper.PiOver2;
			}
			else if (Timer == 60) {
				Projectile.friendly = true;
				Projectile.velocity = new Vector2(0, -12f).RotatedBy(Projectile.rotation);
			}
		}
		public override void PostAI() {
			Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HeartCrystal);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
		}
		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HeartCrystal);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White; //Color.White*((255f-Projectile.alpha)/255f);

			Vector2 scale = new Vector2(1f, 1f);
			if (Timer < 40) scale = new Vector2(Timer/40f, 1f);

		    for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), Color.White, Projectile.rotation, drawOrigin, scale, SpriteEffects.None, 0f);

		    return false;
		}
	}   
}