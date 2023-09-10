using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class LihzahrdLance : SpearProj
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lihzahrd Lance");
		}
		public LihzahrdLance() : base(-20f, 24, 45f, 20f, 2, 30, 60f, 0f, 1.5f, false, false, false) { }
		public override void SpearDefaultsSafe()
		{
			Projectile.width = 80;
			Projectile.height = 76;
		}

		public override void SpearInRadianSwing()
		{
			if (Duration % (RadianSwingFrames / 7) == 0)
			{
				for (int i = 0; i < 6; i++)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Lihzahrd);
					dust.noGravity = true;
					dust.scale = 0.8f;
					dust.velocity = Projectile.velocity * 6f;
				}
				SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
				if (Main.myPlayer == Projectile.owner)
				{
<<<<<<< HEAD
					MovementFactor = 1.5f; //3
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 1.2f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 1.05f; //2.1
				}
			}
			Projectile.position += Projectile.velocity * MovementFactor;
			if (projOwner.itemAnimation == 0) {
				Projectile.Kill();
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (Projectile.spriteDirection == -1) {
				Projectile.rotation -= MathHelper.ToRadians(90f);
=======
					float SwingMulti = -1;
					if (SwingNumber == 1)
						SwingMulti = 1;

					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, (Projectile.velocity * 15f).RotatedBy(MathHelper.ToRadians((MathHelper.SmoothStep((RadianSwingRotation / 2f), ((RadianSwingRotation / 2f) * -1f), Duration / (float)RadianSwingFrames) * SwingMulti))), ModContent.ProjectileType<LihzahrdBeam>(), (int)(Projectile.damage * 0.7f), 2f, Main.myPlayer);
				}
>>>>>>> ProjectClash
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Lihzahrd);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}
		public override void SpearDraw(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras)
		{
			if (SwingNumber != 2)
			{
				Texture2D AfterEffect = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Spears/LihzahrdLance_after");

				for (int k = 0; k < Projectile.oldPos.Length; k++)
				{
					float FakeRotation = Projectile.oldRot[k];
					if (Projectile.spriteDirection == -1)
					{
						FakeRotation += MathHelper.PiOver2;
					}
					Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
					Color colorAfterEffect = Projectile.GetAlpha(Color.White) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
					spriteBatch.Draw(AfterEffect, drawPosEffect, null, colorAfterEffect, FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
				}
			}
		}
	}
}
