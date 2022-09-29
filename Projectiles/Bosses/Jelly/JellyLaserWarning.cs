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
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position - (Projectile.velocity*-Projectile.timeLeft), Projectile.velocity, ModContent.ProjectileType<JellyLaser>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
		}
	}
}