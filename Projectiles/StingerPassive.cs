using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class StingerPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Stinger");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 11), false);
		}
	}   
}