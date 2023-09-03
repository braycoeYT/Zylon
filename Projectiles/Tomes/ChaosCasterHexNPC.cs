using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.Projectiles.Tomes
{
	public class HexNPC : GlobalNPC
	{
        public override bool InstancePerEntity => true;

        public int Hexes = 0;
        public int HexesCollideTimer = 0;
        public int HexesPlayer = 0;
        public float FadeIn = 1f;
        private float HexesScaleMulti = 1f;
        private float HexesRotation = 0f;

        public override void AI(NPC npc)
        {
            if (Hexes > 0)
            {
                // The rotation needs to be added in here otherwise it will still rotate while the game is paused.
                HexesRotation += 0.09f;
                FadeIn += 0.07f;
                HexesCollideTimer--;
                if (HexesCollideTimer <= 0)
                {
                    // For obvious reasons we only want the projectiles that damage the NPC to spawn once.
                    if (HexesPlayer == Main.myPlayer)
                    {
                        Projectile.NewProjectileDirect(npc.GetSource_FromAI(), npc.Center, Vector2.Zero, ModContent.ProjectileType<HexNPCDamage>(), 25 * Hexes, 0f, HexesPlayer, 0f, 0f);
                    }

                    HexesPlayer = 0;
                    Hexes = 0;
                }

            }
            else HexesCollideTimer = 120;
            base.AI(npc);
        }


        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            base.PostDraw(npc, spriteBatch, screenPos, drawColor);
            if (Hexes > 0)
            {
                Texture2D Hex = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/ChaosCasterHexEffect");
                Texture2D Highlight = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/ChaosCasterHexEffect_highlight");

                float HexScale;
                // Finds how big it should draw the (base) hex effect
                if (npc.height > npc.width)
                {
                    HexScale = npc.height / (float)Hex.Width;
                }
                else
                {
                    HexScale = npc.width / (float)Hex.Width;
                }

                if (HexesCollideTimer > 30)
                {
                    HexesScaleMulti = 1f;
                } else
                {
                    float progress = 1f - (HexesCollideTimer / 28.5f);
                    HexesScaleMulti = MathExtras.TensionStep(1f, 0f, progress, 0.2f, 0.2f);
                }

                HexScale = (HexScale * HexesScaleMulti) + (1f * HexesScaleMulti);
                Vector2 DrawOriginHex = Hex.Size() * 0.5f;
                Vector2 drawPos = npc.Center - screenPos + new Vector2(0f, npc.gfxOffY);

                for (int h = 0; h <= Hexes; h++)
                {
                    if (h < Hexes)
                    {
                        Main.spriteBatch.Draw(Highlight, drawPos, null, Color.White * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.6f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Highlight, drawPos, null, Color.White * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.4f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Highlight, drawPos, null, Color.White * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.2f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Hex, drawPos, null, Color.White, HexesRotation / (float)h, DrawOriginHex, HexScale + ((h - 1) * (HexScale / 3.5f)), SpriteEffects.None, 0f);
                    } else if (h == Hexes)
                    {
                        Main.spriteBatch.Draw(Highlight, drawPos, null, (Color.White * FadeIn) * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.6f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Highlight, drawPos, null, (Color.White * FadeIn) * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.4f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Highlight, drawPos, null, (Color.White * FadeIn) * 0.2f, HexesRotation / (float)h, DrawOriginHex, (HexScale + ((h - 1) * (HexScale / 3.5f))) - 0.2f, SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Highlight, drawPos, null, Color.White * FadeIn, HexesRotation / (float)h, DrawOriginHex, HexScale + ((h - 1) * (HexScale / 3.5f)), SpriteEffects.None, 0f);
                        Main.spriteBatch.Draw(Hex, drawPos, null, Color.White * FadeIn, HexesRotation / (float)h, DrawOriginHex, HexScale + ((h - 1) * (HexScale / 3.5f)), SpriteEffects.None, 0f);
                    }
                }



            }

        }
    }
    

    public class HexNPCDamage : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chaos Hex");
        }

        public override string Texture => "Zylon/Projectiles/Tomes/ChaosBallFriendly";

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 2;
        }

        public override void Kill(int timeLeft)
        {
            for (int d = 0; d < 40; d++)
            {
                Dust.NewDust(Projectile.Center, 0, 0, DustID.Shadowflame, Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(-6, 6), 0, Color.White, 1.3f);
            }
        }



        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }


    }

}