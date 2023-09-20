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
	public class Pentagram : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Pentagram");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		bool done;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.12f;
			if (Timer >= 40 || goBack) {
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					for (int i = 0; i < 5; i++) {
						Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red);
						dust.noGravity = false;
						dust.scale = 2f;
					}
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-18f*speedAcc;
			}
			else if (Timer >= 25) Projectile.velocity *= 0.95f;
		}
        /*public override void PostAI() {
            if (Main.rand.NextBool(3)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}*/
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.tileCollide = false;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.92f;
			return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			int verycool = Main.rand.Next(0, 72);
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red);
				dust.noGravity = false;
				dust.scale = 2f;
			}
			if (done) return;
			done = true;
			for (int i = 0; i < 5; i++)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -14).RotatedBy(MathHelper.ToRadians((i*72)+verycool)), ModContent.ProjectileType<Pentagram_2>(), (int)(Projectile.damage*0.65f), Projectile.knockBack/2, Projectile.owner);
            Projectile.Kill();
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				int verycool = Main.rand.Next(0, 72);
				for (int i = 0; i < 5; i++)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Red);
					dust.noGravity = false;
					dust.scale = 2f;
				}
				if (done) return;
				done = true;
				for (int i = 0; i < 5; i++)
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -14).RotatedBy(MathHelper.ToRadians((i * 72) + verycool)), ModContent.ProjectileType<Pentagram_2>(), (int)(Projectile.damage * 0.65f), Projectile.knockBack / 2, Projectile.owner);
				Projectile.Kill();
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
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/Pentagram_2_tracer");

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