using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;

namespace Zylon.Projectiles.Puzzles
{
	public class FamiliarBookCraftingAnim : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ghastly Familiar Book");
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 40;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		float FakeScale;
        public override void AI() {
			if (Projectile.ai[0] == 0)
            {
				SoundEngine.PlaySound(new SoundStyle($"Zylon/Sounds/Items/SecretComplete") { Volume = 1.3f, PitchVariance = 0.0f, MaxInstances = 2, }, Projectile.Center);
			}

			Projectile.ai[0]++;
			Projectile.alpha -= 10;
			if (Projectile.ai[0] <= 60)
            {
				Projectile.velocity.Y -= 0.07f;
            }
			if (Projectile.ai[0] > 60 && Projectile.ai[0] <= 120)
			{
				Projectile.velocity.Y += 0.07f;
			}
			if (Projectile.ai[0] >= 200)
            {
				Lighting.AddLight(Projectile.Center, 0.8f, 0.8f, 0.8f);
			} else
            {
				Lighting.AddLight(Projectile.Center, Projectile.ai[0] / 25f, Projectile.ai[0] / 25f, Projectile.ai[0] / 25f);
			}
			if (Projectile.ai[0] >= 200)
            {
				Projectile.alpha = 255;
            }
			if (Projectile.ai[0] >= 275)
			{
				Projectile.Kill();
			}
			FakeScale = Projectile.ai[0] / 65f;
		}

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
			overWiresUI.Add(index);
        }
        public override bool PreDraw(ref Color lightColor)
        {
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D bloom = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");
			Texture2D RayofLight = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/RayOfLight");

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 bloomOrigin = bloom.Size() / 2f;
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

			if (Projectile.ai[0] >= 200)
            {
				drawPos += Main.rand.NextVector2CircularEdge(MathHelper.SmoothStep(20f, 0f, (Projectile.ai[0] - 200f) / 75f), MathHelper.SmoothStep(20f, 0f, (Projectile.ai[0] - 200f) / 75f));
			} else
            {
				drawPos += Main.rand.NextVector2CircularEdge(MathHelper.SmoothStep(0f, 20f, Projectile.ai[0] / 200f), MathHelper.SmoothStep(0f, 20f, Projectile.ai[0] / 200f));
			}

			Color color = Projectile.GetAlpha(Color.White);

			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, FakeScale, SpriteEffects.None, 0f);

			for (int r = 0; r < (Projectile.ai[0] / 30); r++)
            {
				Main.spriteBatch.Draw(RayofLight, drawPos, null, color * 0.3f, Projectile.rotation + (r * 2.2f) + (Projectile.ai[0]/(30f + (r * 17f))), bloomOrigin, FakeScale * 1.5f + (r / 3.5f), SpriteEffects.None, 0f);
			}

			if (Projectile.ai[0] >= 100)
            {
				for (int r = 0; r < ((Projectile.ai[0] - 100f) / 17); r++)
				{
					Main.spriteBatch.Draw(RayofLight, drawPos, null, color * 0.25f, Projectile.rotation + (r * 1.2f) + (Projectile.ai[0] / 30f), bloomOrigin, FakeScale * 1.5f + (r / 4.5f), SpriteEffects.None, 0f);
				}
			}

			Main.spriteBatch.Draw(bloom, drawPos, null, color * MathHelper.SmoothStep(0f, 0.3f, Projectile.ai[0]/200f), Projectile.rotation, bloomOrigin, FakeScale * 2f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(bloom, drawPos, null, color * MathHelper.SmoothStep(0f, 0.45f, Projectile.ai[0] / 200f), Projectile.rotation, bloomOrigin, FakeScale * 1.6f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(bloom, drawPos, null, color * MathHelper.SmoothStep(0f, 0.6f, Projectile.ai[0] / 200f), Projectile.rotation, bloomOrigin, FakeScale * 1.3f, SpriteEffects.None, 0f);
			if (Projectile.ai[0] >= 150 && Projectile.ai[0] < 200)
            {
				Main.spriteBatch.Draw(bloom, drawPos, null, color * MathHelper.SmoothStep(0f, 1.4f, (Projectile.ai[0] - 150f) / 50f), Projectile.rotation, bloomOrigin, MathHelper.SmoothStep(0f, 30f, (Projectile.ai[0] - 150f) / 50f), SpriteEffects.None, 0f);
			}
			if (Projectile.ai[0] >= 200)
            {
				Main.spriteBatch.Draw(bloom, drawPos, null, Color.White * MathHelper.SmoothStep(1.4f, 0f, (Projectile.ai[0] - 200f) / 75f), Projectile.rotation, bloomOrigin, MathHelper.SmoothStep(30f, 0f, (Projectile.ai[0] - 200f) / 75f), SpriteEffects.None, 0f);
			}

			return false;
		}

    }   
}