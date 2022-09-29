using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Ammo
{
	public class SharpenedFang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sharpened Fang");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Stake);
			Projectile.scale = 1.6f;
			AIType = ProjectileID.Stake;
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Bleeding, 60*Main.rand.Next(8, 17));
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Bleeding, 60*Main.rand.Next(8, 17));
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 6; i++)
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, (int)(Projectile.velocity.X*Main.rand.NextFloat(-0.8f, -1.2f)), (float)(Projectile.velocity.Y*Main.rand.NextFloat(-0.8f, -1.2f)));
		}
	}   
}