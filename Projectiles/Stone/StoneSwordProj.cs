using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Stone
{
    public class StoneSwordProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Sword");
            // These trail variables are required for the trail shenangins. Only mess with them if you know what you are doing.
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            // Net important makes sure the projectile isn't too screwed on logins.
            Projectile.netImportant = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            // Makes sure the player won't hit through tiles.
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        // We need to enstate progress 2 outside of any hooks so it applies to the entire class.
        float progress2;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;

            // Pretty much makes sure that the projectile always matches the animation swing time.
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            // Normalizes the velocity for consistencys sake.
            Projectile.velocity = Vector2.Normalize(Projectile.velocity);
            // This code needs to run only once, so we check for zero only.
            if (Projectile.ai[0] == 0)
            {
                // Adding Pi times 2 makes sure the number is never zero, but keeps the number consistent with where it should be.
                Projectile.ai[0] = Projectile.velocity.ToRotation() + (MathHelper.Pi * 2f);

                // Store the direction in local ai for less wacky animations.
                // For some reaon this HAS to be negative direction for it to look halway decent, the player will always swing the wrong way at the start but without it being negative they will only swing the right way once.
                Projectile.localAI[0] = -Projectile.direction;
            }
            // Wacky player visuals.
            player.heldProj = Projectile.whoAmI;
            player.ChangeDir((int)Projectile.localAI[0]);
            player.itemRotation = (Projectile.velocity * (int)Projectile.localAI[0]).ToRotation();

            // Grabs the half duration of the swing, if this classes code is used elsewhere this could technically be used to make projectiles mid swing
            float halfDuration = duration * 0.5f;
            float progress;

            // Projectile AI 1 is used to determine the swing direction.
            // We pretty much use that to just determine how to increase or decrease progress.
            if (Projectile.ai[1] == 0)
            {
                progress = Projectile.timeLeft / (duration * 1.1f);
            } else
            {
                progress = 1 - (Projectile.timeLeft / (duration * 1.1f));
            }

            // This controls progress 2, which controls a fake size draw in the predraw hook and the distance from the player.
            if (Projectile.timeLeft < halfDuration)
            {
                progress2 = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress2 = (duration - Projectile.timeLeft) / halfDuration;
            }

            // Move the Projectile out from the player based on the rotation stored earlier. Basically stops the sword from being swung from the hilt.
            Projectile.Center = player.MountedCenter + new Vector2(Projectile.height * 0.35f, 0f).RotatedBy(Projectile.ai[0]);
            // These two determine swing radius. TODO: Make these actually change depending on Projectile AI 1 so you can have a smaller startup and a bigger followthrough on swings.
            float RotMax = MathHelper.PiOver2 * 1.875f;
            float RotMin = MathHelper.PiOver2 * 1.875f;

            Projectile.rotation = MathHelper.SmoothStep(Projectile.ai[0] - RotMin, Projectile.ai[0] + RotMax, (progress));

            // Moves the projectile farther out from the player till it reaches the center.
            Projectile.Center += new Vector2(MathHelper.SmoothStep(20f, 38f, progress2), 0f).RotatedBy(Projectile.rotation);

            // THIS is why we need to store the velocity. This controls a bunch of things for the player visuals but it also would screw everything up if the original isn't stored first.
            Projectile.velocity = new Vector2(1f, 0f).RotatedBy(Projectile.rotation);

            // Based on sprite direction we just have to fix the sprites so they look halfway decent. This HAS to happen after the code above otherwise it will do some wacky shit.
            // If you want to see what I mean try putting it after the rotation equals, it's kind of funny.
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.ToRadians(135f);
            }
            else
            {
                Projectile.rotation += MathHelper.ToRadians(45f);
            }

        }

        public override bool PreDraw(ref Color lightColor)
        {
            // This just controls when to flip the projectile horizontally.
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            // This is the fake scale. It is used to exxagerate the swing, it looks awkward without it.
            float fakescale = Projectile.scale + MathHelper.SmoothStep(-0.5f, 0.3f, progress2);

            // This just grabs the projectiles texture, with the one below it grabbing the "overlay" which we use for the after effect
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Stone/StoneSwordProj_overlay");

            // Grabs the draw origin of the projectile by making a Vector2 that grabs the width and height of the projectile.
            // Grabbing the width of the actual texture makes things more centered.
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            // This code right here draws the after images of the projectile.
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                // This grabs where the image should be drawn by pretty much doing the same process as the one above but with the old position.
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                // Funny fade.
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                // This actually draws the trail effect. Take note of the Projectile.oldRot[k].
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, fakescale, spriteEffects, 0);
            }

            // This straight up just draws the actual sword.
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, fakescale, spriteEffects, 0f);

            return false;
        }


    }
}