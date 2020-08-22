using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Mecharang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mecharang");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 630;
			projectile.ignoreWater = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
			projectile.timeLeft = 999;
			Vector2 velocity2 = projectile.velocity;
			velocity2 *= 2;
			if (Timer % 180 == 0 || Timer % 180 == 30 || Timer % 180 == 60) {
				Main.PlaySound(SoundID.Item12);
				Projectile.NewProjectile(projectile.Center, velocity2, ProjectileID.Bullet, projectile.damage, projectile.knockBack / 3, Main.myPlayer);
			}
		}
	}   
}