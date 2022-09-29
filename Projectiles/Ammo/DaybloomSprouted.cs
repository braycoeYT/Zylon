using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class DaybloomSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Daybloom");
        }
		public override void SetDefaults() {
			Projectile.width = 12; //16
			Projectile.height = 16; //36
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 3;
			Projectile.rotation = 0;
		}
	}   
}