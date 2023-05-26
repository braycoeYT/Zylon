using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using System;

namespace Zylon.Projectiles.Swords
{
	public class MudslingerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mudslinger");
			Main.projFrames[Projectile.type] = 6;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 3;
		}
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            damage = (int)(damage*(0.5f+(0.5f*pwr)));
        }
        int Timer;
		bool init;
		float pwr;
		public override void AI() {
			if (!init && Main.myPlayer == Projectile.owner) {
				init = true;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<MudslingerProj_2>(), 0, 0, Projectile.owner, Projectile.whoAmI);
			}
			pwr += 0.015f;
			if (Main.player[Projectile.owner].ZoneMeteor || Main.player[Projectile.owner].ZoneUnderworldHeight) pwr += 0.005f;
			else if (Main.player[Projectile.owner].ZoneDesert) pwr += 0.0025f;
			else if (Main.player[Projectile.owner].ZoneJungle || Main.player[Projectile.owner].ZoneBeach) pwr -= 0.0025f;
			else if (Main.player[Projectile.owner].ZoneSnow || Main.player[Projectile.owner].ZoneSkyHeight || Main.player[Projectile.owner].ZoneNormalSpace) pwr -= 0.005f;
			if (pwr > 1) pwr = 1;
			Projectile.velocity.Normalize();
			Projectile.velocity *= (float)Math.Pow(8f, pwr);
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(Projectile.Center, 0.75f*pwr, 0f, 0f);
			if (pwr == 1) {
				Timer++;
				if (Timer > 29 || Main.player[Projectile.owner].ZoneMeteor || Main.player[Projectile.owner].ZoneUnderworldHeight) {
					if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 5; x++) Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, Projectile.velocity.RotatedByRandom(MathHelper.PiOver4/2), ModContent.ProjectileType<MudslingerProj_3>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
					Projectile.Kill();
                }
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.NextFloat(0.75f) < pwr) {
				target.AddBuff(BuffID.OnFire, (int)(Main.rand.Next(8, 10)*60*pwr));
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            if (Main.rand.NextFloat(0.75f) < pwr) {
				target.AddBuff(BuffID.OnFire, (int)(Main.rand.Next(8, 10)*60*pwr));
            }
        }
        public override void PostAI() {
			if (pwr < 0.3f) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (pwr < 0.6f) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}