using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class CogwheelProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 13;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
        int Timer;
		float speedAcc;
		bool goBack;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.2f;

			if (Timer >= 30 || goBack) {
				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.06f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-30f*speedAcc;
			}
			else if (Timer >= 15) Projectile.velocity *= 0.9f;

			if (Timer % 10 == 0 && Main.myPlayer == Projectile.owner) for (int i = 0; i < 8; i++) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 13).RotatedBy(MathHelper.ToRadians(i*45)), ModContent.ProjectileType<CogwheelProj_Cog>(), (int)(Projectile.damage/0.5f), Projectile.knockBack/2f, Projectile.owner);
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.damage = (int)(Projectile.damage*0.7f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;

			if (Main.rand.NextBool(10) && !target.boss) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), 90);
		}
		public override void PostAI() {
            if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SteampunkSteam);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			//goBack = true;
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
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(12, 12); //- new Vector2(Projectile.width/2, Projectile.height/2);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }   
}