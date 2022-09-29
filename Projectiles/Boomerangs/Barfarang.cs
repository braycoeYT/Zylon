using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Barfarang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Barfarang");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
	}   
}