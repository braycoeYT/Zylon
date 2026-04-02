using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class AlbinoMandibladeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        }
		public override void SetDefaults() {
			Projectile.width = 42;
			Projectile.height = 42;
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
            if (!hitEnemy && Projectile.owner == Main.myPlayer && Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<AlbinoMandibladeProjInvis>()] < 5) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AlbinoMandibladeProjInvis>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner, Projectile.Center.X, Projectile.Center.Y, Projectile.ai[2]);
				hitEnemy = true;
			}
			Projectile.damage = (int)(Projectile.damage*0.6f);
        }
        bool hitEnemy;
        int Timer;
        public override void AI() {
            Timer++;
			if (Timer == 1) {
				Vector2 temp = new Vector2(Projectile.ai[0], Projectile.ai[1]);
				/*int rot = 1;
				if (Main.rand.NextBool()) rot = -1;
				Projectile.velocity = Projectile.Center.DirectionTo(temp).RotatedBy(MathHelper.ToRadians(45*rot))*-12f;*/
				Projectile.velocity = Projectile.Center.DirectionTo(temp).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-45, 45)))*-12f;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
			}
			else if (Timer < 45) {
				Projectile.velocity *= 0.95f;
				bool foundTarget = false;
			    if (!Main.npc[(int)Projectile.ai[2]].active) {
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
								Projectile.ai[2] = i;
							}
						}
					}
				}
			    else foundTarget = true;

				if (foundTarget) Projectile.rotation = Projectile.Center.DirectionTo(Main.npc[(int)Projectile.ai[2]].Center).ToRotation() + MathHelper.PiOver4;
			}
			else if (Timer == 45) {
				Projectile.velocity = new Vector2(0, -8).RotatedBy(Projectile.rotation + MathHelper.PiOver4);
				Projectile.friendly = true;
			}
			else {
				if (Timer > 75) Projectile.tileCollide = true;
				Projectile.velocity *= 1.02f;
			}
			
        }
        public override void PostAI() {
            if (Timer > 45 && Timer % 1 == 0) {
				Dust dust = Dust.NewDustDirect(Projectile.Center - Projectile.velocity*-1, 1, 1, DustID.Firework_Pink);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Vector2.Normalize(Projectile.velocity)*4f; //Vector2.Zero;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = lightColor; //Color.White*((255f-Projectile.alpha)/255f);

            //Regular
		    for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            //Glowmask
            Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/AlbinoMandibladeProj_Glow");
            Main.spriteBatch.Draw(texture2, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

		    return false;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch);
				dust.noGravity = true;
				dust.scale = 1.25f;
			}
		}
    }   
}