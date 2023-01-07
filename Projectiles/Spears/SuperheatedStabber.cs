using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class SuperheatedStabber : SpearProj
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Superheated Stabber");
		}
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 60;
            Projectile.height = 60;
        }
        public SuperheatedStabber() : base(-23f, 24, 7.8f, 55f, 4, 30, 60f, 0f, 1.5f, false, false, false) { }

		public override void PostAI()
		{
			if (Main.rand.NextBool(2))
			{
                int DustType;
                if (Main.player[Projectile.owner].GetModPlayer<SuperheatedStabberPlayer>().Overheat >= 10)
                {
                    DustType = ModContent.DustType<Dusts.OverheatDust>();
                } else if (Main.player[Projectile.owner].GetModPlayer<SuperheatedStabberPlayer>().Heat >= 180)
                {
                    DustType = ModContent.DustType<Dusts.MoltenDust>();
                }
                else
                {
                    DustType = DustID.Obsidian;
                }
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustType);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}

        public override void SpearExtraSetupGlobal()
        {
            Player ProjectileOwner = Main.player[Projectile.owner];
            var SuperheatedPlayer = ProjectileOwner.GetModPlayer<SuperheatedStabberPlayer>();

            if (SuperheatedPlayer.Heat >= 200)
            {
                SuperheatedPlayer.Overheat += 1;
            }

            SuperheatedPlayer.Heat += 15;
            SuperheatedPlayer.HeatCooldown = 0;

            RadianSwingFrames -= (SuperheatedPlayer.Heat / 25);
            RadianSwingRotation += (SuperheatedPlayer.Heat / 10f);
            RadianSwingReach += (SuperheatedPlayer.Heat / 18f);

            ThrustFrames -= (SuperheatedPlayer.Heat / 25);
            ThrustReach += (SuperheatedPlayer.Heat / 18f);

            FreezeFrames -= (SuperheatedPlayer.Heat / 50);

            if (SuperheatedPlayer.Overheat > 6)
            {
                int OverheatUseValue = (SuperheatedPlayer.Overheat - 6);

                ThrustFrames += (OverheatUseValue / 2);
                RadianSwingFrames += (OverheatUseValue / 2);
            }
        }
        public override void SpearDrawBefore(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
        {
            Player ProjectileOwner = Main.player[Projectile.owner];
            var SuperheatedPlayer = ProjectileOwner.GetModPlayer<SuperheatedStabberPlayer>();
            if (SuperheatedPlayer.Overheat > 6)
            {
                Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_moltenglow");
                float SuperheatMultiplier = ((SuperheatedPlayer.Overheat - 6) / 15f) * 0.1f;

                Color drawColor = (Color.Lerp(Projectile.GetAlpha(new Color(255, 218, 137)), Projectile.GetAlpha(new Color(211, 53, 133)), ((SuperheatedPlayer.Overheat - 6) / 15f))) * SuperheatMultiplier;

                for (int g = 0; g < 2; g++)
                {
                    spriteBatch.Draw(glow, drawPosition + new Vector2(3f * g, 0f), null, drawColor, drawRotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(glow, drawPosition + new Vector2(-3f * g, 0f), null, drawColor, drawRotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(glow, drawPosition + new Vector2(0f, 3f * g), null, drawColor, drawRotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(glow, drawPosition + new Vector2(0f, -3f * g), null, drawColor, drawRotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
                }
            }
        }

        public override void SpearDraw(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
        {
            Texture2D Molten = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_molten");
            Player ProjectileOwner = Main.player[Projectile.owner];
            var SuperheatedPlayer = ProjectileOwner.GetModPlayer<SuperheatedStabberPlayer>();

            spriteBatch.Draw(Molten, drawPosition, null, Projectile.GetAlpha(Color.White) * (SuperheatedPlayer.Heat / 200f), drawRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            if (SuperheatedPlayer.Overheat > 6)
            {
                Texture2D Overheat = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/SuperheatedStabber_overheat");
                spriteBatch.Draw(Overheat, drawPosition, null, Projectile.GetAlpha(Color.White) * ((SuperheatedPlayer.Overheat - 6) / 15f), drawRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
        }

    }
    public class SuperheatedStabberPlayer : ModPlayer
    {
        public int Heat;
        public int Overheat;
        public int HeatCooldown;
        public override void ResetEffects()
        {
            if (Heat > 200)
                Heat = 200;

            if (Overheat > 21)
                Overheat = 21;

            if (Heat > 1)
            {
                HeatCooldown++;
                if (HeatCooldown > 60)
                    Heat -= (HeatCooldown / 60);

                if (Heat < 0)
                    Heat = 0;
            } else
            {
                Heat = 0;
                HeatCooldown = 0;
            }

            base.ResetEffects();
        }
    }
}