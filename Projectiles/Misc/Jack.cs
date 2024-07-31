using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Misc
{
	public class Jack : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			AIType = ProjectileID.Shuriken;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 600;
			Projectile.penetrate = 5;
			Projectile.width = 16;
			Projectile.height = 16;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            //Projectile.damage = (int)(Projectile.damage*0.75f);
			Projectile.velocity *= -0.7f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (bounceTimer > 15) { 
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			bounceTimer = 0;
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.7f;
			return false;
        }
		float realRot = Main.rand.NextFloat(MathHelper.TwoPi);
		int bounceTimer;
        public override void AI() {
			Projectile.velocity *= 0.99f;
			if (Projectile.velocity.Y < 0) Projectile.velocity.Y *= 0.95f;
			bounceTimer++;
        }
        public override void PostAI() {
            realRot += Projectile.velocity.X*0.02f;
			Projectile.rotation = realRot;
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}