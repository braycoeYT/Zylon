using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Minions
{
	public class RagingSunProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 180;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 9)*60);
        }
        int Timer;
		Vector2 targetSpeed;
        public override void PostAI() {
			Timer++;
            Projectile.rotation += 0.03f;
			if (Timer < 30) Projectile.velocity *= 0.95f;
			else if (Timer == 30) { 
				Projectile.velocity = Vector2.Zero;
				NPC target = Main.npc[(int)Projectile.ai[0]];
				targetSpeed = Projectile.Center.DirectionTo(target.Center);
			}
			else if (Timer < 60) {
				Projectile.velocity += targetSpeed*0.2f;
			}
			else {
				Projectile.tileCollide = true;
				Projectile.velocity *= 1.01f;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 5; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
				Dust dust = Main.dust[dustIndex];
				dust.velocity = new Vector2(0, Main.rand.NextFloat(3f, 7f)).RotatedByRandom(MathHelper.TwoPi);
				dust.scale *= 1f + Main.rand.Next(-80, 81) * 0.01f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}