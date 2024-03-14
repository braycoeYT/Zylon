using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Yoyos
{
	public class AmazonPrime : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			//130-400 Vanilla, 16 is one tile
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 288f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 11.2f;
		}
		public override void SetDefaults() {
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 120 == 0) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 1), ModContent.ProjectileType<AmazonPackageFall>(), Projectile.damage, 0, Projectile.owner);
		}
	}
}