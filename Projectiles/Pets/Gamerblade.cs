using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Diagnostics.Metrics;

namespace Zylon.Projectiles.Pets
{
	public class Gamerblade : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 54;
            Projectile.height = 54;
        }
        float newRot;
        int spinCounter;
        float spinCounter2;
        int spinDir;
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            if (!player.dead && player.HasBuff<Buffs.Pets.Gamerblade>())
                Projectile.timeLeft = 2;
            return true;
        }
        public override void AI() {
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
			float inertia = 25f;
			if (distanceToIdlePosition > 600f) {
				speed = 50f;
				inertia = 13f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 10f;
                inertia = 15f;
            }

			if (distanceToIdlePosition > 20f) {
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else {
                Projectile.velocity *= 0.85f;
                if (Projectile.velocity.Length() < 0.01f) {
                    if (spinCounter == 0) {
                        spinDir = -1;
                        if (Main.rand.NextBool()) spinDir = 1;
                    }
                    spinCounter++;
                    if (spinCounter > 180) spinCounter2 += 0.1f;
                    if (spinCounter2 > 30f) spinCounter2 = 30f;
                    //Main.NewText(spinCounter + " | " + spinCounter2);
                }
            }
            if (!(Projectile.velocity.Length() < 0.01f)) { //You have to gradually reset this, otherwise it looks weird.
                spinCounter = 0;
                    
                spinCounter2 -= 0.5f;
                if (spinCounter2 < 0) spinCounter2 = 0;
            }
            Projectile.rotation += MathHelper.ToRadians(spinCounter2*spinDir);
            #endregion
        }
        public override void PostAI() {
            newRot = 0.02f*(Math.Abs(Projectile.velocity.X))*(Projectile.velocity.X/Math.Abs(Projectile.velocity.X)); //+Math.Abs(Projectile.velocity.Y)
            Projectile.rotation += newRot;
            //Lighting.AddLight(Projectile.Center, 0.5f, 0.5f, 0.5f);
            Projectile.spriteDirection = 0;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width*0.5f, Projectile.height*0.5f);// + new Vector2(13, 13); //+ drawOrigin
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.6f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}