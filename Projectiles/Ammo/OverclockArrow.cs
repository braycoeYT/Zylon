using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class OverclockArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Overclock Arrow");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			AIType = ProjectileID.WoodenArrowFriendly;
			Projectile.arrow = true;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 30 == 29) {
				int damageInc = 1;
				if (Projectile.damage*0.03f > 1f) damageInc = (int)(Projectile.damage*0.03f);
				Projectile.damage += damageInc;
			}
			if (Timer > 450)
				Timer = 451;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}