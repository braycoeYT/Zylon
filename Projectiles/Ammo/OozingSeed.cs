using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class OozingSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Oozebit");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			Projectile.width = 12;
			Projectile.height = 12;
			AIType = ProjectileID.Seed;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<OozeCloud>(), Projectile.damage/4, 0f, Projectile.owner);
		}
	}   
}