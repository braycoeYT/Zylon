using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Ammo
{
	public class BloodiedArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bloodied Arrow");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 4;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
		bool init;
        public override void AI() {
			if (!init) {
				if (Main.player[Projectile.owner].magicQuiver) Projectile.extraUpdates = 1;
				init = true;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}