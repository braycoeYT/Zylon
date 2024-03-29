using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class DiskiteMinion_SpikeRing : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Desert Diskite");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
		}
		bool init;
		public override void AI() {
			if (!init) {
				if (Main.player[Projectile.owner].ownedProjectileCounts[Projectile.type] > Main.player[Projectile.owner].maxMinions) {
					Projectile.active = false;
					Projectile.timeLeft = 0;
					return;
                }
				init = true;
            }
			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.timeLeft = 60;
			Projectile.active = main.active;
			Projectile.Center = main.Center;
			Projectile.rotation += 0.05f;
			//if (main.timeLeft >= 240) Projectile.active = false;
		}
	}
}