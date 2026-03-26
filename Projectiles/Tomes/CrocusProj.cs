using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Tomes
{
	public class CrocusProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 15;
			Projectile.tileCollide = false;
		}
		float lightAlpha;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.5f);
				dust.velocity = new Vector2(0, -8).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
            Projectile.damage = (int)(Projectile.damage*0.75f);
			if (Projectile.ai[0] == 1f && target.type != NPCID.TargetDummy) heal = true;
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				if (Projectile.ai[0] == 1f) heal = true;
				for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.5f);
				dust.velocity = new Vector2(0, -8).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (Projectile.ai[0] == 1f) { 
				//if (Timer < 15) return false;
				//Projectile.ai[0] = 2f;
				//Projectile.tileCollide = false;
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				return false;
			}
			else return true;
        }
        float offset = Main.rand.NextFloat(MathHelper.TwoPi);
		float spinRot = 0f;
		float scale = Main.rand.NextFloat(0.75f, 1.5f);
		int collisionTimer;
		int Timer;
		bool heal;
        public override void AI() {
			if (Projectile.ai[0] == 0f) { //Spin around player mode
				Projectile.velocity = Vector2.Zero;
				Projectile.Center = Main.player[Projectile.owner].Center + new Vector2(0, 120).RotatedBy(offset + MathHelper.ToRadians(spinRot));

				spinRot += 8f/scale;

				if (spinRot > 360) {
					Projectile.ai[0] = 1f;
					Projectile.tileCollide = true;
				}
			}
			else if (Projectile.ai[0] == 1f) {
				if (Timer == 0) {
					Vector2 wow = Main.player[Projectile.owner].Center.DirectionTo(Main.MouseWorld) + Projectile.Center.DirectionTo(Main.MouseWorld);
					wow /= 2; //Averages both vectors for a cool effect.
					Projectile.velocity = wow*50f;
				}
				else Projectile.velocity *= 0.92f;
				Timer++;
				if (Timer > 30) Projectile.ai[0] = 2f;
			}
			else if (Projectile.ai[0] == 2f) {
				//This timer is just for if it is forced into this mode due to tile collision
				collisionTimer++;
				if (collisionTimer > 20) Projectile.tileCollide = true;

				float speed = 16f*collisionTimer/20f; if (speed > 32f) speed = 32f;
				Projectile.velocity = Projectile.Center.DirectionTo(Main.player[Projectile.owner].Center) * speed;

				if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) < 32f) {
					if (heal) Main.player[Projectile.owner].Heal(Main.rand.Next(2)+1);
					Projectile.Kill();
				}

				if (collisionTimer > 120) Projectile.Kill();
			}
        }
        public override void PostAI() {
			Projectile.rotation += MathHelper.ToRadians(16f);
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkTorch);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1.5f);
				dust.velocity = new Vector2(0, -8).RotatedByRandom(MathHelper.TwoPi)*dust.scale;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);
			if (heal) color = Color.LightGreen;

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.8f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, scale, SpriteEffects.None, 0f);

            return false;
        }
	}   
}