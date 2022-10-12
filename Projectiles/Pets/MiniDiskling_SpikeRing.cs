using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Pets
{
	public class MiniDiskling_SpikeRing : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mini Diskling");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
		}
		public override void AI() {
			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.timeLeft = 60;
			Projectile.active = main.active;
			Projectile.Center = main.Center;
			Projectile.rotation += 0.12f;
			//if (main.timeLeft >= 240) Projectile.active = false;
		}
	}
}