using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Guns
{
	public class PizazzCannonProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = Main.rand.Next(90, 151);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 30;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.timeLeft = 2;
			Projectile.tileCollide = false;
			return false;
        }
        bool init;
		Color myColor = Color.White;
        public override bool PreAI() {
			if (Projectile.timeLeft == 2) {
				Projectile.width *= 4;
				Projectile.height *= 4;
			}
            return true;
        }
        public override void AI() {
			if (!init) {
				int red = Main.rand.Next(256);
				int green = Main.rand.Next(256);
				while (red + green > 256) green = Main.rand.Next(256);
				int blue = 255 - (red+green);
				myColor = new Color(red, green, blue);

				init = true;
			}

			Lighting.AddLight(Projectile.Center, myColor.ToVector3());
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

			//new Color(myColor.R, myColor.G, myColor.B, color.A)
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, myColor, Projectile.rotation, drawOrigin, Projectile.scale*1.5f, SpriteEffects.None, 0f);
            return false;
        }
	}   
}