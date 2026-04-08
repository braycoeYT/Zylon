using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class CalciteSupremeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 90;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 240;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (!hitEnemy && Projectile.owner == Main.myPlayer && target.type != NPCID.TargetDummy) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, new Vector2(0, 12).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<CalciteSupremeBoulder>(), Projectile.damage, Projectile.knockBack/2, Projectile.owner);
				hitEnemy = true;
			}
			Projectile.damage = (int)(Projectile.damage*0.75f);
        }
        bool hitEnemy;
        int Timer;
		float targetX;
		bool everFoundTarget;
        public override void AI() { //ai0 = orientation (0 = below, 1 = above), ai1 = target
            Timer++;
			if (Timer == 1) {
				Projectile.alpha = 127;
				if (Projectile.ai[0] == 0) {
					Projectile.rotation = MathHelper.ToRadians(-45);
					Projectile.Center += new Vector2(0, 480);
				}
				else {
					Projectile.rotation = MathHelper.ToRadians(135);
					Projectile.Center -= new Vector2(0, 480);
				}
			}
			else if (Timer < 90) {
				Projectile.velocity *= 0.95f;
				bool foundTarget = false;
			    if (!Main.npc[(int)Projectile.ai[1]].active) {
					float distanceFromTarget = 200f;
					Vector2 targetCenter = Projectile.position;
						
					for (int i = 0; i < Main.maxNPCs; i++) {
						NPC npc = Main.npc[i];

						if (npc.CanBeChasedBy()) {
							float between = Vector2.Distance(npc.Center, Projectile.Center);
							bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
							bool closeThroughWall = distanceFromTarget < 125f;
	
							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
								Projectile.ai[1] = i;
							}
						}
					}
				}
			    else foundTarget = true;

				if (foundTarget) {
					everFoundTarget = true;

					targetX = Main.npc[(int)Projectile.ai[1]].Center.X;
					float targetY = Main.npc[(int)Projectile.ai[1]].Center.Y + 480;
					if (Projectile.ai[0] == 1f) targetY = Main.npc[(int)Projectile.ai[1]].Center.Y - 480;

					if (Projectile.Center.X < targetX) Projectile.velocity.X += 2.5f;
					else Projectile.velocity.X -= 2.5f;

					if (Projectile.Center.Y < targetY) Projectile.velocity.Y += 2f;
					else Projectile.velocity.Y -= 2f;

					Projectile.velocity *= 0.96f;
				}
				else Projectile.velocity *= 0.85f;
			}
			else if (Timer == 90) {
				Projectile.velocity = new Vector2(0, -16 + 32*Projectile.ai[0]);
				Projectile.friendly = true;
				Projectile.alpha = 0;
			}
			else if (Timer >= 120) {
				Projectile.alpha += 12;
				if (Projectile.alpha > 254) Projectile.Kill();
			}

			if (Timer > 90 && everFoundTarget) {
				targetX = Main.npc[(int)Projectile.ai[1]].Center.X;
				if (Main.npc[(int)Projectile.ai[1]].active) {
					if (Projectile.Center.X < targetX) Projectile.velocity.X += 2.5f;
					else Projectile.velocity.X -= 2.5f;
				}
			}
        }
        public override void PostAI() {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Yellow);
			dust.noGravity = true;
			dust.scale = 1f;
        }
        public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White*((255f-Projectile.alpha)/255f);

		    for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin + new Vector2(-28, 0);
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

		    return false;
		}
    }   
}