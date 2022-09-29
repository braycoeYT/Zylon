using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Boomerangs
{
	public class Mecharang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mecharang");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.friendly = true;
			Projectile.penetrate = 999;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
		int Timer = 60;
		public override void AI() {
			Timer++;
			if (Timer % 120 == 0) {
				for (int i = 0; i < 8; i++)
					Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2(0, 10).RotatedBy(MathHelper.ToRadians(45*i)), ModContent.ProjectileType<EyeLaserFriendly>(), Projectile.damage, Projectile.knockBack / 3, Main.myPlayer);
			}
		}
	}   
}