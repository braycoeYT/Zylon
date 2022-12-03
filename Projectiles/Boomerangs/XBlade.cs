using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class XBlade : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("X-Blade");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 5;
			Projectile.tileCollide = false;
			Projectile.scale = 1.25f;
			Projectile.light = 1f;
			Projectile.extraUpdates = 2;
		}
		int Timer;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.1f;
			if (Timer > 48) {
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 60) Projectile.Kill();
				speed.Normalize();
				Projectile.velocity = speed*-20f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Ichor, Main.rand.Next(5, 15) * 60);
			target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 15) * 60);
			if (Main.rand.NextBool(10)) {
				if (Main.rand.NextBool()) {
					for (int i = 0; i < 13; i++) {
						Vector2 cool = new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(i*360/13));
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center-160*cool, cool*12f, ModContent.ProjectileType<XBlade_NoName>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
					  }
				}
				else {
					for (int i = 0; i < 7; i++) {
						Vector2 cool = new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(i*360/7));
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center-160*cool, cool*12f, ModContent.ProjectileType<XBlade_OrbofLight>(), 0, 0f, Projectile.owner);
				    }
				}
			}
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Ichor, Main.rand.Next(5, 15) * 60);
			target.AddBuff(BuffID.Blackout, Main.rand.Next(5, 15) * 60);
			if (Main.rand.NextBool(10)) {
				if (Main.rand.NextBool()) {
					for (int i = 0; i < 13; i++) {
						Vector2 cool = new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(i*360/13));
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center-160*cool, cool*12f, ModContent.ProjectileType<XBlade_NoName>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
					  }
				}
				else {
					for (int i = 0; i < 7; i++) {
						Vector2 cool = new Vector2(0, 1).RotatedBy(MathHelper.ToRadians(i*360/7));
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center-160*cool, cool*12f, ModContent.ProjectileType<XBlade_OrbofLight>(), 0, 0f, Projectile.owner);
				    }
				}
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            // This just controls when to flip the projectile horizontally.
            SpriteEffects spriteEffects = SpriteEffects.None;
            //if (Projectile.spriteDirection == -1)
            //    spriteEffects = SpriteEffects.FlipHorizontally;

            // This is the fake scale. It is used to exxagerate the swing, it looks awkward without it.
            float fakescale = Projectile.scale;// + MathHelper.SmoothStep(-0.5f, 0.3f, (float)Timer/60);

            // This just grabs the projectiles texture, with the one below it grabbing the "overlay" which we use for the after effect
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/XBlade_tracer");

            // Grabs the draw origin of the projectile by making a Vector2 that grabs the width and height of the projectile.
            // Grabbing the width of the actual texture makes things more centered.
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            // This code right here draws the after images of the projectile.
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                // This grabs where the image should be drawn by pretty much doing the same process as the one above but with the old position.
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                // Funny fade.
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                // This actually draws the trail effect. Take note of the Projectile.oldRot[k].
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, fakescale, spriteEffects, 0);
            }

            // This straight up just draws the actual sword.
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, fakescale, spriteEffects, 0f);

            return false;
        }
	}   
}