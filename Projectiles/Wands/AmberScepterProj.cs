using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.IO;

namespace Zylon.Projectiles.Wands
{
	public class AmberScepterProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			Projectile.DamageType = DamageClass.Magic;
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer == 45) {
				Projectile.velocity = Vector2.Normalize(Projectile.Center - Main.MouseWorld)*-6f;
			}
			if (Timer > 45 && Projectile.velocity.Length() < 12f) Projectile.velocity *= 1.05f;

			if (Projectile.timeLeft < 20) Projectile.alpha += 13;
        }
        public override void PostAI() {
			Projectile.rotation += 0.05f;
            Lighting.AddLight(Projectile.Center, 0.8f, 0.6f, 0.23f);
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
				//new Vector2(0f, Projectile.scale*(10-k)*0.3f) //(k*(1f-k*0.05f))
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.scale*(10-k)*0.3f); //Projectile.gfxOffY
                Main.EntitySpriteDraw(texture, drawPos, null, Color.White*((float)(255-Projectile.alpha)/255f), Projectile.rotation, drawOrigin, Projectile.scale*(10-k)*0.1f, SpriteEffects.None, 0);
            }
            return false;
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.25f);
				dust.velocity = new Vector2(0, -6).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}