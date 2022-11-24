using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Zylon.Projectiles.Misc
{
	public class AquaBubble : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 1800;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 3;
		}
		int Timer;
        public override void AI() {
            Projectile.velocity *= 0.98f;
			if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < 0.1f) {
				Timer++;
				Projectile.alpha += 15;
			}
			if (Timer > 29) Projectile.Kill();
			Projectile.rotation += 0.05f;
        }
        public override void Kill(int timeLeft) {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.WaterDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}