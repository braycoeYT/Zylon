using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Blowpipes
{
	public class HollowKnifeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (targetNum < 0) targetNum = target.whoAmI;
			if (Projectile.timeLeft > 15) Projectile.timeLeft = 15;
			Projectile.tileCollide = false;
			//Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			newCenter = Projectile.Center;
			if (Projectile.timeLeft > 15) Projectile.timeLeft = 15;
			Projectile.tileCollide = false;

			//Projectile.Kill();
            return false;
        }
        int targetNum = -1;
		Vector2 newCenter;
        public override void AI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;

            if (Projectile.velocity.Length() > 5f) for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.WhiteDust>());
				dust.velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(12f))*-0.5f;
				dust.noGravity = true;
				dust.scale = 1f;
			}
			else if (Projectile.timeLeft > 45) Projectile.timeLeft = 45;

			if (Projectile.timeLeft < 15) Projectile.alpha += 17;
        }
        public override void OnKill(int timeLeft) {
			if (targetNum > -1) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<HollowKnifeProjInvis>(), Projectile.damage, Projectile.knockBack, Projectile.owner, targetNum, Projectile.ai[0]);
			}
			else {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), newCenter, Vector2.Zero, ModContent.ProjectileType<HollowKnifeProjInvis>(), Projectile.damage, Projectile.knockBack, Projectile.owner, -1f, Projectile.ai[0]);
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Blowpipes/HollowKnifeProj");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White; //Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}