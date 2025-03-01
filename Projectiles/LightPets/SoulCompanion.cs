using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.LightPets
{
	public class SoulCompanion : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 45;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.width = 76;
            Projectile.height = 76;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
        }
        int offset = 0;
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.LightPets.SoulCompanion>())
                Projectile.timeLeft = 2;

            if (player.direction == 1 && offset < 80) {
                offset += 4;
            }
            else if (player.direction == -1 && offset > -80) {
                offset -= 4;
            }

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8) { Projectile.frame++; Projectile.frameCounter = 0; }
            if (Projectile.frame > 3) Projectile.frame = 0;

            Projectile.Center = player.Center + new Vector2(offset, -40 + player.gfxOffY);
            Projectile.velocity = Vector2.Zero;

            Projectile.direction = player.direction;
            Projectile.rotation = MathHelper.ToRadians(player.velocity.X);

            return true;
        }
        public override void PostAI() {
            //newRot += 0.02f*(Math.Abs(Projectile.velocity.X))*(Projectile.velocity.X/Math.Abs(Projectile.velocity.X)); //+Math.Abs(Projectile.velocity.Y)
            float glow = 0.4f;
            if (Main.hardMode) glow = 2f;
            Lighting.AddLight(Projectile.Center, Main.DiscoColor.ToVector3()*glow);
            Projectile.spriteDirection = Projectile.direction; //(int)(Projectile.velocity.X/Math.Abs(Projectile.velocity.X));
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D orbTexture = TextureAssets.Projectile[Projectile.type].Value;

            String textureName = "Zylon/Projectiles/LightPets/SoulCompanion_" + Projectile.frame;
            Texture2D mainTexture = (Texture2D)ModContent.Request<Texture2D>(textureName);

            Vector2 drawOrigin = new Vector2(orbTexture.Width * 0.5f, Projectile.height);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Main.DiscoColor;

            SpriteEffects dir = SpriteEffects.None;
            if (Projectile.spriteDirection == -1) dir = SpriteEffects.FlipHorizontally;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + new Vector2(Projectile.width*0.5f, Projectile.height*0.5f);// + new Vector2(13, 13); //+ drawOrigin
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.6f;
                Main.spriteBatch.Draw(orbTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale*(1f-(float)k/Projectile.oldPos.Length), SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(orbTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(mainTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, dir, 0f);

            return false;
        }
    }   
}