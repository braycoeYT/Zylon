using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Armor
{
    public class ArgentumOrb_MeleeSword : ModProjectile
    {
        public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 20;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
        }
        int Timer;
        float rot;
        float progress;
        float offset;
        float offsetFloat;
        Projectile owner;
        public override void AI() {
            if (Timer == 0) {
                owner = Main.projectile[(int)Projectile.ai[0]];
                rot = owner.Center.DirectionTo(Main.npc[(int)Projectile.ai[1]].Center).ToRotation();
            }
            if (Timer == 10 && Projectile.ai[2] % 5 == 0 && Main.myPlayer == Projectile.owner) {
                SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/ArgentumOrbSFX").WithPitchOffset(Main.rand.NextFloat(1f)).WithVolumeScale(0.25f), Projectile.position);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -16).RotatedBy(rot + MathHelper.PiOver2), ModContent.ProjectileType<ArgentumOrb_MeleeSwordProj>(), Projectile.damage/2, Projectile.knockBack/2f, Projectile.owner);
            }

            offsetFloat = 0f;
            if (Projectile.ai[2] % 2 == 0) offsetFloat = 1f;
            offset = MathHelper.ToRadians((Timer-10)*7*(-1+2*offsetFloat)); //Does actual swing animation. Alternates directions.

            Projectile.Center = owner.Center + new Vector2(0, -32).RotatedBy(rot + offset + MathHelper.PiOver2);
            Projectile.rotation = rot + offset + MathHelper.PiOver4;
            Timer++;
            //if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White*((255f-Projectile.alpha)/255f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 1f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}