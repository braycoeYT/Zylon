using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Tomes
{
	public class EverlastingBladeProj4 : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
		}
        bool init;
		public override void AI() {
            if (!init) { //Find a target to chase on spawn.
                float distanceFromTarget = 600f;
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
				if (foundTarget) Projectile.velocity = Vector2.Normalize(targetCenter - Projectile.Center) * 18f;
                init = true;
            }
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = new Color(255-Main.DiscoR, 255-Main.DiscoG, 255-Main.DiscoB)*((255f-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY); // - new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                if (k == 0) colorAfterEffect = color;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            //Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}