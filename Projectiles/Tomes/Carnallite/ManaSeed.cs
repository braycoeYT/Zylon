using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Tomes.Carnallite
{
	public class ManaSeed : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mana Seed");
		}

		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}

        public override void AI()
        {
			Projectile.ai[0]++;
			Projectile.velocity.Y += 0.25f;
			if (Projectile.velocity.Y > 16f)
            {
				// Since this projectile spawns another one we absolutley do not want it going through blocks cause of gravity.
				Projectile.velocity.Y = 16f;
            }
			Projectile.rotation += 0.058f + (Projectile.velocity.Length()/40f);

			if (Main.rand.NextBool(7) == true)
            {
				Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CarnalliteTome.ManaDust>());
			}

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			// You are not ready for this overcomplicated dust code.

			// This variable basically determines the rotation amount per a for loop.
			float RotationPerLoop = 0.1f;
			float RandomEndRotation = Main.rand.NextFloat(((float)Math.PI * 1.5f) - 0.12f, ((float)Math.PI * 1.5f) + 0.12f);

			for (float d = 0; d < 6.28f; d += RotationPerLoop)
            {
				// Because dust is complicated we start by combining the two functions that make a circle and assigning them to the correct values.
				float x = (float)Math.Cos(d);
				float y = (float)Math.Sin(d);

				// This controls the actual shape and speed of the dust.
				float BaseMultiplier = 2.3f;
				float Multiplier = BaseMultiplier * (((float)Math.Abs(((d * 2.5f) % (float)Math.PI) - (float)Math.PI / 3f)) + 1.2f) * x;

				// And this spawns the dust.
				Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<Dusts.CarnalliteTome.ManaDust>(), new Vector2(x, y).RotatedBy(RandomEndRotation) * Multiplier, 0, default, 1.3f);
			}

			SoundEngine.PlaySound(SoundID.Item50, Projectile.Center);

			if (Projectile.owner == Main.myPlayer)
            {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ManaFlower>(), 0, 0f, Main.myPlayer, 0f, 0f);
            }


			return true;
        }
        public override bool? CanHitNPC(NPC target)
        {
			// Yea no, this is a support item, so we disable it from hurting any NPCs
            return false;
        }

        public override bool CanHitPvp(Player target)
        {
			// Same with other players
            return false;
        }

        public override bool? CanCutTiles()
        {
			// Also doesn't make much sense for it to destroy tiles, so we just let tiles stay.
            return false;
        }

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D Glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Tomes/Carnallite/ManaSeedGlow");

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);

			Main.spriteBatch.Draw(Glow, drawPos, null, Color.White * 0.4f, Projectile.rotation, drawOrigin, Projectile.scale * 1.15f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(Glow, drawPos, null, Color.White * (1f - (Projectile.ai[0] / 30f)), Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

			return false;
		}

	}
}