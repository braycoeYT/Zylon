using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class AridBoStaffProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Arid Winds");
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = true;
            Projectile.rotation = Main.rand.NextFloat(6.28f);
		}

        public override void AI()
        {
            Projectile.rotation += 0.12f;

			if (Projectile.ai[0] == 0)
            {
				SoundEngine.PlaySound(SoundID.DD2_PhantomPhoenixShot, Projectile.position);
			}

            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 60)
            {
                Projectile.alpha += 3;
                if (Projectile.alpha >= 230)
                {
                    Projectile.Kill();
                }
            }

			if (Main.rand.NextBool(3))
            {
				Dust.NewDust(Projectile.Center + new Vector2(0f, -105f), 25, 175, DustID.Sandnado, 0f, Main.rand.NextFloat(-15f, -30f));
            }

        }

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

			Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);

			float FakeScale = Projectile.ai[0]/32f;

			if (FakeScale > 1f)
				FakeScale = 1f;

			for (int k = 0; k < 15; k++)
            {
				Main.spriteBatch.Draw(projectileTexture, drawPos + new Vector2(0f, (-5f * k)) + new Vector2(0f, 15f), null, color * 0.14f, Projectile.rotation - (k * 0.1f), drawOrigin, FakeScale + (k * 0.1f), SpriteEffects.None, 0f);
			}

			return false;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }


    }   
}