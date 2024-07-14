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
		}
		bool init;
		int Timer;
        public override void AI() {
			if (!init) {
				if (Main.player[Projectile.owner].magicQuiver) Projectile.extraUpdates = 1;
				init = true;
			}
            Timer++;
			if (Timer % 30 == 29)
				Projectile.damage += 1;
			if (Timer > 450)
				Timer = 451;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}