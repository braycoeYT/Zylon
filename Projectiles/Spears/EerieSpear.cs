using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class EerieSpear : SpearProj
	{
        public override void SpearDefaultsSafe() {
			Projectile.width = 54;
			Projectile.height = 54;
		}
        public EerieSpear() : base(-18f, 32, 7.8f, 56f, 0, 55, 365f, 0f, 2.3f, false, false, false) { }


        public override void SpearInRadianSwing()
        {
            if (Duration % (RadianSwingFrames/4) == 0)
            {
				for (int i = 0; i < 6; i++)
                {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JellyDust>());
					dust.noGravity = true;
					dust.scale = 0.8f;
					dust.velocity = Projectile.velocity * 6f;
				}
				if (Main.myPlayer == Projectile.owner)
                {
					float SwingMulti = -1;
					if (SwingNumber == 1)
						SwingMulti = 1;

					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, (Projectile.velocity * 15f).RotatedBy(MathHelper.ToRadians((MathHelper.SmoothStep((RadianSwingRotation / 2f), ((RadianSwingRotation / 2f) * -1f), Duration/(float)RadianSwingFrames) * SwingMulti))), ModContent.ProjectileType<EerieSpearProj>(), (int)(Projectile.damage * 0.3f), 2f, Main.myPlayer);
				}
			}
        }

        public override void SpearInThrustSwing()
        {
			if (Duration == (ThrustFrames / 2))
			{
				for (int i = 0; i < 6; i++)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JellyDust>());
					dust.noGravity = true;
					dust.scale = 1.2f;
					dust.velocity = Projectile.velocity * 8f;
				}
				if (Main.myPlayer == Projectile.owner)
				{
					for (int p = 0; p < 4; p++)
                    {
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, (Projectile.velocity * Main.rand.NextFloat(10f, 15f)).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(((RadianSwingRotation / 2f) * -1f), (RadianSwingRotation / 2f)))), ModContent.ProjectileType<EerieSpearProj>(), (int)(Projectile.damage * 0.3f), 2f, Main.myPlayer);
					}
				}
			}
		}
		public override void SpearDrawBefore(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
		{
			if (SwingNumber == 2)
            {
				Texture2D AfterEffect = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/EerieSpear_after");

				for (int k = 0; k < Projectile.oldPos.Length; k++)
				{
						Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
						Color colorAfterEffect = Projectile.GetAlpha(Color.White) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
						spriteBatch.Draw(AfterEffect, drawPosEffect, null, colorAfterEffect, drawRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				}

				Texture2D link = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/EerieSpear_link");

				// Below is taken from Example Mods Advanced Flail, figured there was no point in me writing my own system to achieve the exact same thing

				Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);
				playerArmPosition.Y -= Main.player[Projectile.owner].gfxOffY;

				Rectangle? chainSourceRectangle = null;
				float chainHeightAdjustment = 0f;

				Vector2 chainOrigin = chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (link.Size() / 2f);
				Vector2 chainDrawPosition = Projectile.Center;
				Vector2 vectorFromProjectileToPlayerArms = playerArmPosition.MoveTowards(chainDrawPosition, 4f) - chainDrawPosition;
				Vector2 unitVectorFromProjectileToPlayerArms = vectorFromProjectileToPlayerArms.SafeNormalize(Vector2.Zero);
				float chainSegmentLength = (chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : link.Height) + chainHeightAdjustment;
				if (chainSegmentLength == 0)
				{
					chainSegmentLength = 10;
				}
				float chainRotation = unitVectorFromProjectileToPlayerArms.ToRotation() + MathHelper.PiOver2;
				int chainCount = 0;
				float chainLengthRemainingToDraw = vectorFromProjectileToPlayerArms.Length() + chainSegmentLength / 2f;

				while (chainLengthRemainingToDraw > 0f)
				{
					Color chainDrawColor = Lighting.GetColor((int)chainDrawPosition.X / 16, (int)(chainDrawPosition.Y / 16f));

					Main.spriteBatch.Draw(link, chainDrawPosition - Main.screenPosition, chainSourceRectangle, chainDrawColor, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);

					chainDrawPosition += unitVectorFromProjectileToPlayerArms * chainSegmentLength;
					chainCount++;
					chainLengthRemainingToDraw -= chainSegmentLength;
				}


			}
		}

		public override void PostAI() {
			if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.JellyDust>());
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}
	}
}