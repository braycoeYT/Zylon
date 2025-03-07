using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class ElectricBoltPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Electric Bolt");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = ProjectileID.Bullet;
		}
		bool init;
		public override void AI() {
			if (!init) switch (Projectile.ai[0]) {
				case 0f: Projectile.DamageType = DamageClass.Melee;
					return;
				case 1f: Projectile.DamageType = DamageClass.Ranged;
					return;
				case 2f: Projectile.DamageType = DamageClass.Magic;
					return;
				case 3f: Projectile.DamageType = DamageClass.Summon;
					return;
            }
			init = true;
			if (++Projectile.frameCounter >= 4) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}