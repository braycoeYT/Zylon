using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.MagicGuns
{
	public class ElectricBoltPassiveExplodeExp : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electricity");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			switch (Projectile.ai[0]) {
				case 0f: Projectile.DamageType = DamageClass.Melee;
					return;
				case 1f: Projectile.DamageType = DamageClass.Ranged;
					return;
				case 2f: Projectile.DamageType = DamageClass.Magic;
					return;
				case 3f: Projectile.DamageType = DamageClass.Summon;
					return;
            }
			Projectile.ai[0] = 0f;
		}
		public override void AI() {
			for (int i = 0; i < 5; i++) {
				int dustType = DustID.Electric;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}