using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Yoyos
{
	public class DirtBlockYoyo : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Block");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 240;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		int rand1 = Main.rand.Next(0, 360);
		int rand2 = Main.rand.Next(8, 17);
        public override void AI() {
			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation += 0.05f;
			Projectile.Center = main.Center - new Vector2(0, rand2).RotatedBy(MathHelper.ToRadians(rand1));
			if (Projectile.timeLeft > 15) Projectile.alpha -= 10;
			else Projectile.alpha += 30;
			if (main.active == false) Projectile.active = false;
        }
	}   
}