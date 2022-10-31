using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Dirtball
{
	public class DirtboiTears : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtboi's Tears");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = false;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}