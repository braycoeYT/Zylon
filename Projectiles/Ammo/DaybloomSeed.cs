using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class DaybloomSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Daybloom Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		bool a = true;
        public override void AI() {
            if (Main.dayTime && a) {
				Projectile.damage += 4;
				a = false;
            }
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 6), ModContent.ProjectileType<DaybloomSeedFall>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
		}
	}   
}