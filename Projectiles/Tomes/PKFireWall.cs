using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Projectiles.Tomes
{
	public class PKFireWall : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Volcanic Flame");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 20;
			Projectile.height = 60;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 240;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.rotation = 0;
			Projectile.DamageType = DamageClass.Magic;
			//Projectile.usesLocalNPCImmunity = true;
			//Projectile.localNPCHitCooldown = 10;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5), false);
		}
		public override void AI() {
			for (int i = 0; i < 4; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}