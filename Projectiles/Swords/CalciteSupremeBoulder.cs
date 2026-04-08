using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class CalciteSupremeBoulder : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BouncyBoulder);
			AIType = ProjectileID.BouncyBoulder;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.hostile = false;
			Projectile.penetrate = 99;
			Projectile.timeLeft = 300;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Confused, Main.rand.Next(8, 13)*60);
			Projectile.damage = (int)(Projectile.damage*0.75f);
			if (Projectile.damage < 1) Projectile.Kill();
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Confused, Main.rand.Next(8, 13)*60);
		}
        public override void PostAI() {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Yellow);
			dust.noGravity = true;
			dust.scale = 1f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Yellow);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			return false;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Firework_Yellow);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
		    Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;

		    Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
		    Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Color.White; //Color.White*((255f-Projectile.alpha)/255f);

		    for (int k = 0; k < Projectile.oldPos.Length; k++) {
			    Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) + drawOrigin;
			    Color colorAfterEffect = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
			    Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
		    }
		    Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, spriteSheetOffset, projectileTexture.Width, frameHeight)), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

		    return false;
		}
	}   
}