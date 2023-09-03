using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
    public class SuperheatedStabberThrown : ModProjectile
    {
        public override string Texture => "Zylon/Projectiles/Spears/SuperheatedStabber";

        bool Initiated = false;
        bool GeneralStuck = false;
        Vector2 StuckOffset = Vector2.Zero;
        bool Stucktype = false;
        int HitTarget = 1001;
        int StuckTimer = 0;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Superheated Stabber");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.scale = 1.3f;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.oldPos[0] = Projectile.Center;
            for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
            {
                Projectile.oldPos[i] = Projectile.oldPos[i - 1];
            }

            if (!Initiated)
            {
                Player ProjectileOwner = Main.player[Projectile.owner];
                var SuperheatedPlayer = ProjectileOwner.GetModPlayer<SuperheatedStabberPlayer>();

                SuperheatedPlayer.Heat = 0;
                SuperheatedPlayer.Overheat = 0;
                SuperheatedPlayer.HeatCooldown = 0;

                Initiated = true;
            }
            if (!GeneralStuck)
            {
                Projectile.velocity.Y += 0.04f;

                Projectile.rotation = Projectile.velocity.ToRotation();
                if (Projectile.spriteDirection == -1)
                {
                    Projectile.rotation += MathHelper.ToRadians(45f);
                }
                else
                {
                    Projectile.rotation += MathHelper.ToRadians(135f);
                }
            } else
            {
                Projectile.timeLeft = 2;
                Projectile.velocity = Vector2.Zero;
                if (!Stucktype)
                {
                    if (!Main.npc[HitTarget].active || Main.npc[HitTarget].life < 1)
                    {
                        Projectile.Kill();
                    }
                    Projectile.Center = Main.npc[HitTarget].Center + StuckOffset;
                }
                if (StuckTimer == 0)
                    SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Projectiles/FireCharge") { Volume = 0.2f, PitchVariance = 0.0f, MaxInstances = 2, }, Projectile.Center);

                StuckTimer++;
                if (StuckTimer >= 64)
                {
                    Explode();
                }
            }

        }
        public void Explode()
        {
            SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Projectiles/FireBoom") { Volume = 1.2f, PitchVariance = 0.2f, MaxInstances = 2, }, Projectile.Center);

            for (int d = 0; d < 12; d++)
            {
                Dust.NewDust(Projectile.Center, Projectile.height, Projectile.width, ModContent.DustType<Dusts.Effects.SuperheatedSmoke>(), Main.rand.NextFloat(-7, 7), Main.rand.NextFloat(-7, 7));
            }
            for (int d = 0; d < 52; d++)
            {
                Dust.NewDust(Projectile.Center, Projectile.height, Projectile.width, ModContent.DustType<Dusts.Effects.SuperheatedSmokeFastFade>(), Main.rand.NextFloat(-12, 12), Main.rand.NextFloat(-12, 12));
            }
            for (int d = 0; d < 2; d++)
            {
                Dust.NewDust(Projectile.Center, Projectile.height, Projectile.width, ModContent.DustType<Dusts.Effects.SuperheatedSmokeSlowFade>(), Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
            }
            for (int d = 0; d < 22; d++)
            {
                Dust.NewDust(Projectile.Center, Projectile.height, Projectile.width, ModContent.DustType<Dusts.Effects.SuperheatedEmber>(), Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(-5, 2));
            }
            if (Main.myPlayer == Projectile.owner)
            {
                int Damage = (int)((Projectile.ai[0]/5) + ((Projectile.ai[1] - 6) * 8)) + Projectile.damage;
                if (!Stucktype)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Main.npc[HitTarget].Center, Vector2.Zero, ModContent.ProjectileType<SuperheatedStabberThrownBoom>(), Damage, 0f, Projectile.owner, Projectile.ai[1], 0f);
                } else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SuperheatedStabberThrownBoom>(), Damage, 0f, Projectile.owner, Projectile.ai[1], 0f);
                }
            }

            float Distance = 855f;
            float Multi = 1f;
            if (Projectile.ai[1] >= 21)
            {
                Distance += 200f;
                Multi = 1.15f;
            }

            Systems.Camera.CameraController.ScreenshakePoints(20, Distance, Projectile.Center, Main.LocalPlayer.Center, Multi);

            Projectile.Kill();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity = Vector2.Zero;
            HitTarget = target.whoAmI;
            StuckOffset = Projectile.Center - target.Center;
            GeneralStuck = true;
            Projectile.netUpdate = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = Vector2.Zero;
            Stucktype = true;
            GeneralStuck = true;
            return false;
        }
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(GeneralStuck);
            writer.Write(HitTarget);
            writer.WriteVector2(StuckOffset);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            GeneralStuck = reader.ReadBoolean();
            HitTarget = reader.ReadInt32();
            StuckOffset = reader.ReadVector2();
        }
        public override bool? CanDamage()
        {
            if (!GeneralStuck)
            {
                return base.CanDamage();
            } else
            {
                return false;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_moltenglow");
            Texture2D trail = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_moltentrail");
            Texture2D Molten = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_molten");
            Texture2D Overheat = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_overheat");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            if (!GeneralStuck)
            {
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                    Color colorAfterEffect = (Color.Lerp(Projectile.GetAlpha(new Color(255, 218, 137)), Projectile.GetAlpha(new Color(211, 53, 133)), ((Projectile.ai[1] - 6) / 15f))) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                    Main.spriteBatch.Draw(trail, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, SpriteEffects.None, 0);
                }
            }

            if (Projectile.ai[1] > 6)
            {

                float SuperheatMultiplier = ((Projectile.ai[1] - 6) / 15f) * 0.1f;

                Color drawColor = (Color.Lerp(Projectile.GetAlpha(new Color(255, 218, 137)), Projectile.GetAlpha(new Color(211, 53, 133)), ((Projectile.ai[1] - 6) / 15f))) * SuperheatMultiplier;

                for (int g = 0; g < 2; g++)
                {
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(3f * g, 0f), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(-3f * g, 0f), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(0f, 3f * g), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(0f, -3f * g), null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                }
            }

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            Main.spriteBatch.Draw(Molten, drawPos, null, Projectile.GetAlpha(Color.White) * (Projectile.ai[0] / 200f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            if (Projectile.ai[1] > 6)
            {
                Main.spriteBatch.Draw(Overheat, drawPos, null, Projectile.GetAlpha(Color.White) * ((Projectile.ai[1] - 6) / 15f), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            if (GeneralStuck)
            {
                float OpacityMulti = MathHelper.SmoothStep(0f, 1f, (StuckTimer / 120f));
                for (int g = 0; g < 5; g++)
                {
                    OpacityMulti *= 0.8f;
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(1f * g, 0f), null, Projectile.GetAlpha(Color.White) * OpacityMulti, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(-1f * g, 0f), null, Projectile.GetAlpha(Color.White) * OpacityMulti, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(0f, 1f * g), null, Projectile.GetAlpha(Color.White) * OpacityMulti, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(glow, drawPos + new Vector2(0f, -1f * g), null, Projectile.GetAlpha(Color.White) * OpacityMulti, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                }
                OpacityMulti = MathHelper.SmoothStep(0f, 1f, (StuckTimer / 120f));
                Main.spriteBatch.Draw(glow, drawPos, null, Projectile.GetAlpha(Color.White) * OpacityMulti, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(glow, drawPos, null, Projectile.GetAlpha(Color.White) * MathExtras.TensionStep(0.75f, 0.75f, (StuckTimer / 60f), 0.5f, -0.55f), Projectile.rotation, drawOrigin, (Projectile.scale + 8) * MathExtras.TensionStep(0.05f, 0.05f, (StuckTimer / 60f), 0.5f, 0.35f), SpriteEffects.None, 0f);
            }

            return false;
        }
    }
    public class SuperheatedStabberThrownBoom : ModProjectile
    {
        public override string Texture => "Zylon/Projectiles/Spears/SuperheatedStabber";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Superheated Stabber");
        }
        public override void SetDefaults()
        {
            Projectile.width = 228;
            Projectile.height = 228;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 10;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Projectile.ai[0] >= 21)
            {
                modifiers.SetCrit();
            }
        }
    }
}