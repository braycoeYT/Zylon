using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Projectiles.Misc;

namespace Zylon.Projectiles.Spears
{
	public class BigOneSpear : SpearProj
	{
		public BigOneSpear() : base(-20f, 15, 60f, 20f, 0, 22, 90f, 0f, 1.5f, false, false, false) { }
		public override void SpearDefaultsSafe()
		{
			Projectile.width = 70;
			Projectile.height = 70;
		}

		public override void SpearInThrustSwing() {
			if (Duration == (ThrustFrames/2)) {
				Vector2 speed = Vector2.Normalize(Projectile.velocity);
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, speed*13f, ModContent.ProjectileType<BigOneSpear_Throw>(), (int)(Projectile.damage*0.75f), Projectile.knockBack, Projectile.owner);
				Projectile.Kill();
			}
		}
		public override void SpearDraw(SpriteBatch spriteBatch, Color lightColor, Texture2D projectileTexture, Vector2 drawOrigin, Vector2 drawPosition, float drawRotation, int amountOfExtras) {
			Texture2D AfterEffect = TextureAssets.Projectile[Projectile.type].Value;

			float FakeRotation = Projectile.rotation;
			if (Projectile.spriteDirection == -1) FakeRotation += MathHelper.PiOver2;

			Vector2 drawPosEffect = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			spriteBatch.Draw(AfterEffect, drawPosEffect, null, Color.White, FakeRotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		}
	}
}
