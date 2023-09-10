using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Accessories
{
	public class DemonEyeRotate : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Demon Eye");
        }
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.alpha = 255;
		}
		Player main;
		int critBoost;
		float rSpeed;
		float totalRot;
        public override void AI() {
			main = Main.player[Projectile.owner];
			critBoost = (int)Projectile.ai[0];
			if (critBoost < 0) critBoost = 0;
			if (critBoost > 100) critBoost = 100;
			rSpeed = 2 + (5*critBoost/100);
			totalRot += rSpeed;
			Projectile.Center = main.Center - new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(totalRot));
			Projectile.rotation = MathHelper.ToRadians(totalRot);
			if (totalRot < 300) Projectile.alpha -= 10 + (15*critBoost/100);
			else Projectile.alpha += 30 + (30*critBoost/100);
			if (totalRot >= 300 && Projectile.alpha > 254) Projectile.active = false;
        }
	}   
}