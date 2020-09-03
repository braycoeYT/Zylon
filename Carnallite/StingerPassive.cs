using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Carnallite
{
	public class StingerPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Venomous Gel");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(3, 7), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(3, 7), false);
		}
	}   
}