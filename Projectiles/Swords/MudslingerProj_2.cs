using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class MudslingerProj_2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mudslinger");
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
			Projectile.alpha = 255;
			Projectile.frameCounter = 1;
		}
		float pwr;
		public override void AI() {
			pwr += 0.015f;
			if (Main.player[Projectile.owner].ZoneMeteor || Main.player[Projectile.owner].ZoneUnderworldHeight) pwr += 0.005f;
			else if (Main.player[Projectile.owner].ZoneDesert) pwr += 0.0025f;
			else if (Main.player[Projectile.owner].ZoneJungle || Main.player[Projectile.owner].ZoneBeach) pwr -= 0.0025f;
			else if (Main.player[Projectile.owner].ZoneSnow || Main.player[Projectile.owner].ZoneSkyHeight || Main.player[Projectile.owner].ZoneNormalSpace) pwr -= 0.005f;
			if (pwr > 1) pwr = 1;
			Projectile.alpha = 255-(int)(255*pwr);
			Projectile own = Main.projectile[(int)Projectile.ai[0]];
			Projectile.position = own.position;
			Projectile.rotation = own.rotation;
			Projectile.scale = own.scale;
			Projectile.active = own.active;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			if (Projectile.alpha < 150) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (Projectile.alpha < 60) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}