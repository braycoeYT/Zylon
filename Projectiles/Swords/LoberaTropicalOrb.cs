using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Swords
{
	public class LoberaTropicalOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tropical Orb");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.alpha = 255;
		}
		public override void PostAI() {
			Projectile.alpha -= 15;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.boss == false)
		    target.AddBuff(ModContent.BuffType<Buffs.LoberaSoulslash>(), 60 * Main.rand.Next(1, 4), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.LoberaSoulslash>(), 60 * Main.rand.Next(1, 4), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				int dustType = ModContent.DustType<Dusts.LoberaDust>();
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}