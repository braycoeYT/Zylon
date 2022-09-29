using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyBeamY : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Beam");
		}
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 1600;
			Projectile.alpha = 127;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = false;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer > 79) {
				Projectile.hostile = true;
				Projectile.damage = 20;
				if (Main.expertMode) Projectile.damage = 35;
				Projectile.alpha = 0;
			}
		}
	}
}