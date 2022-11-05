using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class LoberaProj : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lobera");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.netImportant = true;
            Projectile.width = 34;
            Projectile.height = 60;
            Projectile.aiStyle = -1;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 5;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            for (int i = 0; i < Main.rand.Next(1, 4); i++) {
                Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-320, 321), Main.player[Projectile.owner].position.Y - 400);
			    Vector2 target2 = spawn - target.Center;
			    Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawn, target2*Main.rand.NextFloat(-8f, -5f), ModContent.ProjectileType<LoberaTropicalOrb>(), damage/2, Projectile.knockBack/2, Main.myPlayer);
                if (target.boss == false) target.AddBuff(ModContent.BuffType<Buffs.LoberaSoulslash>(), 60 * Main.rand.Next(3, 7), false);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            for (int i = 0; i < Main.rand.Next(1, 4); i++) {
                Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-320, 321), Main.player[Projectile.owner].position.Y - 400);
			    Vector2 target2 = spawn - target.Center;
			    Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawn, target2*Main.rand.NextFloat(-8f, -5f), ModContent.ProjectileType<LoberaTropicalOrb>(), damage/2, Projectile.knockBack/2, Main.myPlayer);
                target.AddBuff(ModContent.BuffType<Buffs.LoberaSoulslash>(), 60 * Main.rand.Next(3, 7), false);
            }
        }
        float progress2;
        public override void AI() {
            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;

            player.heldProj = Projectile.whoAmI;
            player.ChangeDir(Projectile.direction);
            player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();

            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity);
            Projectile.ai[0] = Projectile.velocity.ToRotation();


            float halfDuration = duration * 0.5f;
            float progress;

            if (Projectile.ai[1] == 0)
            {
                progress = Projectile.timeLeft / (duration * 1.1f);
            } else
            {
                progress = 1 - (Projectile.timeLeft / (duration * 1.1f));
            }

            if (Projectile.timeLeft < halfDuration)
            {
                progress2 = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress2 = (duration - Projectile.timeLeft) / halfDuration;
            }
            Projectile.Center = player.MountedCenter + new Vector2(Projectile.height * 0.35f, 0f).RotatedBy(Projectile.velocity.ToRotation());
            float RotMax = MathHelper.PiOver2 * 1.875f;
            float RotMin = MathHelper.PiOver2 * 1.875f;
            Projectile.rotation = MathHelper.SmoothStep(Projectile.ai[0] - RotMin, Projectile.ai[0] + RotMax, (progress));
            Projectile.Center += new Vector2(MathHelper.SmoothStep(20f, 38f, progress2), 0f).RotatedBy(Projectile.rotation);
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.ToRadians(135f);
            }
            else
            {
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
        }
        public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            float fakescale = Projectile.scale + MathHelper.SmoothStep(-0.5f, 0.3f, progress2);


            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/LoberaProj_Overlay");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, fakescale, spriteEffects, 0);
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, fakescale, spriteEffects, 0f);

            return false;
        }
    }
}