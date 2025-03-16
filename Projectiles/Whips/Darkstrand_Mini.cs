using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Whips
{
	public class Darkstrand_Mini : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 40;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.6f);
			if (Timer >= 20) hasHit = true;
			if (Projectile.timeLeft > 45) Projectile.timeLeft = 45;
        }
		bool hasHit;
        int Timer;
		public override void AI() {
			Timer++;
			if (Timer < (26+12*(int)Projectile.ai[0])) {
				Projectile.tileCollide = Timer == (26+12*(int)Projectile.ai[0])-1;
			}
			else if (!hasHit) {
				float distanceFromTarget = 300f;
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
							}
						}
					}
				}
				Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * (9+3*(int)Projectile.ai[0]);

				if (foundTarget) Projectile.velocity = Projectile.velocity*0.9f + projDir*0.1f;
			}
			else {
				Projectile.velocity *= 1.1f;
				if (Projectile.velocity.Length() > 32) Projectile.velocity = Vector2.Normalize(Projectile.velocity)*32f;
			}

			Projectile.rotation += 0.05f*Projectile.velocity.Length() + 0.05f;
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			
			Projectile.tileCollide = false;
			if (Projectile.timeLeft > 15) Projectile.timeLeft = 15;
			return false;
        }
        public override void OnKill(int timeLeft) {
			//Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY); // - new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
				if (k == 0) colorAfterEffect = color;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect*((255f-Projectile.alpha)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color*((255f-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}