using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Pets
{
	public class CeroPet : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 34;
            Projectile.height = 24;
        }
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.Pets.CeroandUni>())
                Projectile.timeLeft = 2;
            return true;
        }
        int glitchTimer;
        int Timer;
        int rand = 180;
        int counter;
        int blinkTimer;
        bool init;
        public override void AI() {
            if (!init && Main.myPlayer == Projectile.owner) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<UniPet>(), 0, 0, Projectile.owner);
                init = true;
            }

            Player player = Main.player[Projectile.owner];
            #region General behavior
			Vector2 idlePosition = player.Center + new Vector2(-60*player.direction, -80);
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			#endregion

            #region Movement

			float speed = 30f;
			float inertia = 35f;
			if (distanceToIdlePosition > 600f) {
				speed = 30f;
				inertia = 15f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 12f;
                inertia = 35f;
            }

			if (distanceToIdlePosition > 20f) {
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else if (Projectile.velocity == Vector2.Zero) {
				Projectile.velocity.X = -0.15f;
				Projectile.velocity.Y = -0.05f;
			}
            #endregion

            //Glitching code
            if (glitchTimer < 1) Timer++;
            blinkTimer--;

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 5) {
                Projectile.frame += 1;
                if (Projectile.frame > 3) Projectile.frame = 0;
                Projectile.frameCounter = 0;
            }

            if (Timer > rand) {
                blinkTimer = 5; //Turns red for how long?
                Timer = 0;
                rand = Main.rand.Next(120, 181);
                Projectile.velocity += new Vector2(0, Main.rand.NextFloat(6, 10)).RotatedByRandom(MathHelper.TwoPi);
                counter++;

                if (counter % 5 == 4) glitchTimer = 20; 
            }

            if (glitchTimer > 0) {
                glitchTimer--;
                Projectile.Center += new Vector2(0, Main.rand.Next(32, 80)).RotatedByRandom(MathHelper.TwoPi);
            }
        }
        public override void PostAI() {
            Projectile.spriteDirection = Projectile.direction;
        }
        public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            if (glitchTimer > 0 || blinkTimer > 0) projectileTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/CeroPet_Red");
			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(Projectile.width * 0.5f, Projectile.height * 0.5f); //new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = lightColor; //Color.White*((255f-Projectile.alpha)/255f);
	        
            SpriteEffects dir = SpriteEffects.None;
            if (Projectile.spriteDirection == -1) dir = SpriteEffects.FlipHorizontally;

            //Regular
		    for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, dir, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), color, Projectile.rotation, drawOrigin, Projectile.scale, dir, 0f);
	        

            //Glowmask
            Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/CeroPet_Glow");
            if (glitchTimer > 0 || blinkTimer > 0) texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/CeroPet_GlowRed");
            for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(texture2, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(texture2, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

		    return false;
		}
    }   
}