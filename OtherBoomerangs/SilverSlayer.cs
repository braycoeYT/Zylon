using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class SilverSlayer : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Silver Slayer");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 45;
			projectile.height = 45;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 999;
			projectile.ignoreWater = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
			projectile.timeLeft = 999;
			Vector2 velocity2 = projectile.velocity;
			velocity2 *= 2;
			if (Timer % 60 == 0)
			Projectile.NewProjectile(projectile.Center, velocity2, mod.ProjectileType("SilvervoidPellet"), projectile.damage, 2f, Main.myPlayer);
		}
	}   
}