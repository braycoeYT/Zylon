using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.Projectiles.Misc
{
	public class MagnificentOrbPortal : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magnificent Portal");
			Main.projFrames[Projectile.type] = 4;
		}
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 74;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 1000;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Magic;
		}
		public override void AI() {

			Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}

			Projectile.position += -Projectile.velocity;

			if (Main.rand.NextBool(3))
				Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MagnificentDust>(), (Projectile.velocity.X / 1.5f) + Main.rand.NextFloat(-1.2f, 1.2f), (Projectile.velocity.Y / 1.5f) + Main.rand.NextFloat(-1.2f, 1.2f), 0, Color.White, 1.3f);

			if (++Projectile.frameCounter >= 15)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}

			Projectile.ai[0]++;

			if (Projectile.ai[0] % 12 == 0 && Projectile.ai[0] < 100)
            {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(0f, Main.rand.NextFloat(-16, 16)).RotatedBy(Projectile.rotation), Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-4, 4))), ModContent.ProjectileType<MagnificentOrbStar>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
			}


			if (Projectile.ai[0] < 100)
            {
				Projectile.alpha -= 15;
				if (Projectile.alpha < 0)
                {
					Projectile.alpha = 0;
                }
			}
			else
            {
				Projectile.alpha += 15;
			}
			if (Projectile.ai[0] >= 100 && Projectile.alpha >= 240)
			{
				Projectile.Kill();
			}
		}

        public override bool PreDraw(ref Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D projectileTexture = (Texture2D)ModContent.Request<Texture2D>(Texture);
			Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Misc/MagnificentOrbPortal_glow");

			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			Rectangle sourceRectangle = new Rectangle(0, startY, projectileTexture.Width, frameHeight);

			Vector2 drawOrigin = sourceRectangle.Size() / 2f;

			Color color = Projectile.GetAlpha(lightColor);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

			float FakeScaleMulti = (1f - (Projectile.alpha / 255f));

			if (FakeScaleMulti >= 1f)
            {
				FakeScaleMulti = 1f;
            }
			Vector2 SillyScale = new Vector2(1f * FakeScaleMulti, 1f);

			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color * 0.02f, Projectile.rotation, drawOrigin, (SillyScale * 1.9f), spriteEffects, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color * 0.05f, Projectile.rotation, drawOrigin, (SillyScale * 1.6f), spriteEffects, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color * 0.1f, Projectile.rotation, drawOrigin, (SillyScale * 1.3f), spriteEffects, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color * 0.2f, Projectile.rotation, drawOrigin, (SillyScale * 1.2f), spriteEffects, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color * 0.3f, Projectile.rotation, drawOrigin, (SillyScale * 1.1f), spriteEffects, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color, Projectile.rotation, drawOrigin, SillyScale, spriteEffects, 0f);
			Main.spriteBatch.Draw(glow, drawPos, sourceRectangle, Color.White * (1f - (Projectile.alpha/255f)), Projectile.rotation, drawOrigin, SillyScale, spriteEffects, 0f);


			return false;
        }


        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }
        public override bool CanHitPvp(Player target)
        {
            return false;
        }

    }   
}