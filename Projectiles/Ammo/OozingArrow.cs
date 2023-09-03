using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class OozingArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Oozing Arrow");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			AIType = ProjectileID.WoodenArrowFriendly;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<OozeCloud>(), Projectile.damage/4, 0f, Projectile.owner);
		}
	}   
}