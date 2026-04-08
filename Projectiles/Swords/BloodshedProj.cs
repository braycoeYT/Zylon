using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Swords
{
	public class BloodshedProj : ModProjectile
	{
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = Projectile.damage/2;
			if (Projectile.damage < 1) Projectile.damage = 1;
        }
        int maxTime;
		bool init;
        public override void AI() {
            if (!init) {
				maxTime = Main.rand.Next(60, 91);
				Projectile.timeLeft = maxTime;

				init = true;
			}
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
				dust.noGravity = true;
				dust.scale = (float)Projectile.timeLeft/maxTime + 0.05f;
			}
			Projectile.rotation += 0.08f;
			Projectile.scale = (float)Projectile.timeLeft/maxTime + 0.5f;
		}
		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 3; i++) {
				int dustType = DustID.Blood;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}