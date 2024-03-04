using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyLaserWarning : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(83);
			Projectile.alpha = 127;
			Projectile.hostile = false;
			Projectile.timeLeft = 60;
			Projectile.tileCollide = false;
		}
		public override void OnKill(int timeLeft) {
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.position - (Projectile.velocity*-Projectile.timeLeft), Projectile.velocity, ModContent.ProjectileType<JellyLaser>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, BasicNetType: 2);
		}
	}
}