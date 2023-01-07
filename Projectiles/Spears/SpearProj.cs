using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public abstract class SpearProj : ModProjectile
	{
        private bool Setup;
        public int CurrentFreezeFrames;
        public int SwingNumber;

        public int FreezeFrames;
        public int Duration;
        public float StartPoint;

        public float RadianSwingRotation;
        public float RadianSwingReach;
        public int RadianSwingFrames;

        public int ThrustFrames;
        public float ThrustReach;
        public float ThrustLaunch;
        public float ThrustDamageScaling;

        public bool HasImpactExtra;
        public bool HasGlowmask;
        public bool HasThrustEffect;

        public SpearProj(float StartPoint_input, int RadianSwingFrames_input, float RadianSwingRotation_input, float RadianSwingReach_input, int FreezeFrames_input, int ThrustFrames_input, float ThrustReach_input, float ThrustLaunch_input, float ThrustDamageScaling_input, bool HasGlowmask_input, bool HasThrustEffect_input, bool HasImpactextra_input)
        {
            StartPoint = StartPoint_input;

            RadianSwingFrames = RadianSwingFrames_input;
            RadianSwingRotation = RadianSwingRotation_input;
            RadianSwingReach = RadianSwingReach_input;

            FreezeFrames = FreezeFrames_input;

            ThrustFrames = ThrustFrames_input;
            ThrustReach = ThrustReach_input;
            ThrustLaunch = ThrustLaunch_input;
            ThrustDamageScaling = ThrustDamageScaling_input;

            HasGlowmask = HasGlowmask_input;
            HasThrustEffect = HasThrustEffect_input;
            HasImpactExtra = HasImpactextra_input;
        }

        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 54;
            Projectile.penetrate = -1;
            Projectile.scale = 1.3f;
            Projectile.alpha = 0;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.timeLeft = 200;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 40;
            Projectile.netImportant = true;
            SpearDefaultsSafe();
        }

        public override void AI()
        {
            SpearAISafe();

            Projectile.oldPos[0] = Projectile.Center;
            for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
            {
                Projectile.oldPos[i] = Projectile.oldPos[i - 1];
            }

            Projectile.oldRot[0] = Projectile.rotation;
            for (int i = (Projectile.oldRot.Length - 1); i > 0; i--)
            {
                Projectile.oldRot[i] = Projectile.oldRot[i - 1];
            }

            Player ProjectileOwner = Main.player[Projectile.owner];
            var ZylonSpearPlayer = ProjectileOwner.GetModPlayer<SpearPlayer>();

            if (!Setup)
                SpearExtraSetupGlobal();
            if (!Setup && Main.myPlayer == Projectile.owner)
            {
                SwingNumber = ZylonSpearPlayer.SpearCombo;
                ZylonSpearPlayer.SpearCombo++;
                ZylonSpearPlayer.SpearComboTimer = 240;
                SpearExtraSetup();
                Projectile.netUpdate = true;
                Setup = true;
            }


            Projectile.velocity = Vector2.Normalize(Projectile.velocity);
            Vector2 center = ProjectileOwner.RotatedRelativePoint(ProjectileOwner.MountedCenter);
            Projectile.Center = center;
            Projectile.position += Projectile.velocity * ((Projectile.height * 0.075f) + (Projectile.width * 0.075f));
            ProjectileOwner.heldProj = Projectile.whoAmI;

            if (CurrentFreezeFrames < 1)
            {
                Projectile.rotation = Projectile.velocity.ToRotation();
                Projectile.spriteDirection = Projectile.direction;

                if (Projectile.spriteDirection == -1)
                {
                    Projectile.rotation += MathHelper.ToRadians(-315f);
                }
                else
                {
                    Projectile.rotation += MathHelper.ToRadians(-225f);
                }

                Duration++;

                if (SwingNumber >= 0 && SwingNumber <= 1)
                {
                    float RadianSwingRotationPerFrame = MathHelper.ToRadians(RadianSwingRotation) / (float)RadianSwingFrames;
                    if (SwingNumber == 1)
                        RadianSwingRotationPerFrame *= -1;

                    Projectile.rotation += MathHelper.SmoothStep(-1 * (RadianSwingRotationPerFrame * (RadianSwingFrames/2)), (RadianSwingRotationPerFrame * (RadianSwingFrames / 2)), Duration/(float)RadianSwingFrames);

                    float VectorValue = MathExtras.TensionStep(StartPoint, StartPoint, Duration / (float)RadianSwingFrames, 0.5f, RadianSwingReach);

                    Projectile.Center += new Vector2(VectorValue, 0f).RotatedBy(Projectile.velocity.ToRotation());

                    SpearInRadianSwing();

                    if (Duration > RadianSwingFrames)
                    {
                        Projectile.Kill();
                    }

                } else if (SwingNumber == 2) {

                    if (Duration == 1)
                    {
                        ProjectileOwner.velocity += new Vector2(ThrustLaunch, 0f).RotatedBy(Projectile.velocity.ToRotation());
                    }

                    float VectorValue = MathExtras.TensionStep(StartPoint, StartPoint, Duration / (float)ThrustFrames, 0.5f, ThrustReach);
                    Projectile.Center += new Vector2(VectorValue, 0f).RotatedBy(Projectile.velocity.ToRotation());

                    SpearInThrustSwing();

                    if (Duration > ThrustFrames)
                    {
                        Projectile.Kill();
                    }
                }


            } else
            {
                Projectile.position += -Projectile.velocity;
                CurrentFreezeFrames--;

                if (SwingNumber >= 0 && SwingNumber <= 1)
                {
                    float VectorValue = MathExtras.TensionStep(StartPoint, StartPoint, Duration / (float)RadianSwingFrames, 0.5f, RadianSwingReach);
                    Projectile.Center += new Vector2(VectorValue, 0f).RotatedBy(Projectile.velocity.ToRotation());
                }
                if (SwingNumber == 3)
                {
                    float VectorValue = MathExtras.TensionStep(StartPoint, StartPoint, Duration / (float)ThrustFrames, 0.5f, ThrustReach);
                    Projectile.Center += new Vector2(VectorValue, 0f).RotatedBy(Projectile.velocity.ToRotation());
                }
            }
            

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (SwingNumber == 2 && ThrustLaunch != 0f)
            {
                Player ProjectileOwner = Main.player[Projectile.owner];
                if (Projectile.direction == -1)
                {
                    ProjectileOwner.velocity += new Vector2(ThrustLaunch * 1.5f, -8f);
                } else
                {
                    ProjectileOwner.velocity += new Vector2(-ThrustLaunch * 1.5f, -8f);
                }
            }
            SpearOnHitNPC(target, damage, knockback, crit);

            TriggerFreezeFrames();
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            if (SwingNumber == 2 && ThrustLaunch != 0f)
            {
                Player ProjectileOwner = Main.player[Projectile.owner];
                ProjectileOwner.velocity += new Vector2(-ThrustLaunch, 0f).RotatedBy(Projectile.velocity.ToRotation());
            }
            SpearOnHitPVP(target, damage, crit);

            TriggerFreezeFrames();
            base.OnHitPvp(target, damage, crit);
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (SwingNumber >= 0 && SwingNumber <= 1)
            {
                if ((Duration / (float)RadianSwingFrames) > 0.1f && (Duration / (float)RadianSwingFrames) < 0.9f && CurrentFreezeFrames < 1)
                {
                    return base.CanHitNPC(target);
                } else
                {
                    return false;
                }
            } else
            {
                if ((Duration / (float)ThrustFrames) > 0.1f && (Duration / (float)ThrustFrames) < 0.9f && CurrentFreezeFrames < 1)
                {
                    return base.CanHitNPC(target);
                } else
                {
                    return false;
                }
            }
        }

        public override bool CanHitPvp(Player target)
        {
            if (SwingNumber >= 0 && SwingNumber <= 1)
            {
                return (Duration / (float)RadianSwingFrames) > 0.1f && (Duration / (float)RadianSwingFrames) < 0.9f && CurrentFreezeFrames < 1;
            }
            else
            {
                return (Duration / (float)ThrustFrames) > 0.1f && (Duration / (float)ThrustFrames) < 0.9f && CurrentFreezeFrames < 1;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            int AmountOfExtras = 1;

            if (HasGlowmask)
                AmountOfExtras = 2;
            if (HasThrustEffect)
                AmountOfExtras = 3;
            if (HasImpactExtra)
                AmountOfExtras = 4;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, (projectileTexture.Height/AmountOfExtras) * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            float FakeRotation = Projectile.rotation;
            if (Projectile.spriteDirection == -1)
            {
                FakeRotation += MathHelper.PiOver2;
            }
            SpearDrawBefore(Main.spriteBatch, lightColor, projectileTexture, drawOrigin, drawPos, FakeRotation, AmountOfExtras);
            Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle(0, 0, projectileTexture.Width, (projectileTexture.Height / AmountOfExtras)), color, FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            if (HasGlowmask)
            {
                Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle(0, ((projectileTexture.Height/AmountOfExtras) * 1), projectileTexture.Width, (projectileTexture.Height / AmountOfExtras)), Projectile.GetAlpha(Color.White), FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            SpearDraw(Main.spriteBatch, lightColor, projectileTexture, drawOrigin, drawPos, FakeRotation, AmountOfExtras);
            if (HasThrustEffect && Duration < ThrustFrames && SwingNumber == 2)
            {
                float ColorMulti = MathExtras.TensionStep(0.7f, 0f, (Duration / (float)ThrustFrames), 0.45f, 0.5f);
                Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle(0, ((projectileTexture.Height / AmountOfExtras) * 2), projectileTexture.Width, (projectileTexture.Height / AmountOfExtras)), color * ColorMulti, FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            if (HasImpactExtra && CurrentFreezeFrames >= 1)
            {
                float ColorMulti = MathHelper.SmoothStep(0.2f, 0f, (1f - (CurrentFreezeFrames/(float)FreezeFrames)));
                Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle(0, ((projectileTexture.Height / AmountOfExtras) * 3), projectileTexture.Width, (projectileTexture.Height / AmountOfExtras)), Projectile.GetAlpha(Color.White) * ColorMulti, FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }


            return false;
        }

        public override void ModifyDamageScaling(ref float damageScale)
        {
            if (SwingNumber == 2)
            {
                damageScale *= ThrustDamageScaling;
            }
        }

        private void TriggerFreezeFrames()
        {
            CurrentFreezeFrames = FreezeFrames;
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.netUpdate = true;
            }
            FreezeFramesExtraEffect();
        }

        public virtual void FreezeFramesExtraEffect()
        {
        }
        public virtual void SpearAISafe()
        {
        }
        public virtual void SpearInRadianSwing()
        {
        }
        public virtual void SpearInThrustSwing()
        {
        }
        public virtual void SpearDefaultsSafe()
        {
        }
        public virtual void SpearOnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public virtual void SpearOnHitPVP(Player target, int damage, bool crit)
        {
        }
        public virtual void SpearDraw(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
        {
        }
        public virtual void SpearDrawBefore(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
        {
        }
        public virtual void SpearSendExtraAI(BinaryWriter writer)
        {
        }
        public virtual void SpearReceiveExtraAI(BinaryReader reader)
        {
        }
        public virtual void SpearExtraSetup()
        {
        }
        public virtual void SpearExtraSetupGlobal()
        {
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            SpearSendExtraAI(writer);
            writer.Write(Duration);
            if (FreezeFrames > 0)
            {
                writer.Write(CurrentFreezeFrames);
            }
            writer.Write(SwingNumber);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            SpearReceiveExtraAI(reader);
            Duration = reader.ReadInt32();
            if (FreezeFrames > 0)
            {
                CurrentFreezeFrames = reader.ReadInt32();
            }
            SwingNumber = reader.ReadInt32();
        }

    }



    // Keep all this white space, I want it to be obvious that the ModPlayer below is a seperate class.

    public class SpearPlayer : ModPlayer
    {
        public int SpearCombo;
        public int SpearComboTimer;
        public override void ResetEffects()
        {
            if (SpearCombo >= 3)
            {
                SpearCombo = 0;
            }
            if (SpearComboTimer >= 1)
            {
                SpearComboTimer--;
                if (SpearComboTimer == 0)
                {
                    SpearCombo = 0;
                }
            }
            base.ResetEffects();
        }
    }

}