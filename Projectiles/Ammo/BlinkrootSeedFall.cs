using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class BlinkrootSeedFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Blinkroot Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = -1;
		}
        public override bool? CanHitNPC(NPC target) {
            return false;
        }
        public override bool CanHitPvp(Player target) {
            return false;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center - new Vector2 (0, 0), new Vector2 (0, 0), ModContent.ProjectileType<BlinkrootSprouted>(), Projectile.damage, 0f, Projectile.owner);
		}
	}   
}