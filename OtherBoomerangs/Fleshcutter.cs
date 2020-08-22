using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Fleshcutter : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flesh Cutter");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
			projectile.width = 45;
			projectile.height = 45;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 999;
			projectile.ignoreWater = true;
		}
		public override void AI() {
			projectile.timeLeft = 999;
		}
	}   
}