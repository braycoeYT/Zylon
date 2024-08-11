using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Boomerangs
{
	public class Solaris : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 105;
			Projectile.height = 105;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 40;
			Projectile.extraUpdates = 3;
			Projectile.tileCollide = false;
		}
		int crazy;
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type == NPCID.TargetDummy) return;
			float rand = Main.rand.NextFloat(0f, 60f);
			if (Projectile.owner == Main.myPlayer) {
				if (Main.rand.NextBool()) for (int x = 0; x < 6; x++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0.8f).RotatedBy(MathHelper.ToRadians(rand+(x*60))), ModContent.ProjectileType<Solaris_Shot>(), Projectile.damage/3, Projectile.knockBack/3, Main.myPlayer);
				}
				if (Main.rand.NextFloat() < .3f) {
					crazy++;
					if (crazy < 3) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Solaris_Stick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 0f);
				}
			}
            
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP && Projectile.owner == Main.myPlayer) {
				float rand = Main.rand.NextFloat(0f, 60f);
				if (Main.rand.NextFloat() < .15f) {
					crazy++;
					if (crazy < 2) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Solaris_Stick>(), Projectile.damage, Projectile.knockBack, Projectile.owner, target.whoAmI, Projectile.rotation, 1f);
				}
				if (Main.rand.NextBool()) for (int x = 0; x < 6; x++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0.8f).RotatedBy(MathHelper.ToRadians(rand+(x*60))), ModContent.ProjectileType<Solaris_Shot>(), Projectile.damage/3, Projectile.knockBack/3, Main.myPlayer);
				}
            }
            
		}
        public override void AI() {
			Projectile.ai[0]++;
			Projectile.rotation += 0.1f;
			if (Projectile.ai[0] > 54) {
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < 60) Projectile.Kill();
				speed.Normalize();
				Projectile.velocity = speed*-10f;
			}
		}
		public override void PostAI() {
			for (int x = 0; x < Main.rand.Next(1, 3); x++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            SpriteEffects spriteEffects = SpriteEffects.None;

            float fakescale = Projectile.scale;

            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/Solaris");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, fakescale, spriteEffects, 0);
            }
			Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, fakescale, spriteEffects, 0f);
            return false;
        }
    }   
}