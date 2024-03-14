using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class MoonglowSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Moonglow Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		bool a = true;
        public override void AI() {
            if (!Main.dayTime && a) {
				Projectile.damage += 5;
				a = false;
            }
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 6), ModContent.ProjectileType<MoonglowSeedFall>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
		}
	}   
}