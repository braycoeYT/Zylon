using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class DiskiteMinion_LaserEye : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Diskite");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
		}
		Vector2 target;
		float degrees;
		float targetRot;
		float degTemp;
		float targTemp;
		float count1;
		float count2;
		float degSpeed;
		bool whatDir;
		Player owner;
		public override void AI() {
			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.timeLeft = 60;
			Projectile.active = main.active;
			Projectile.Center = main.Center + (main.velocity * 1.25f);
		}
	}
}