using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Gemstone
{
	public class GemstoneHeal : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Leech");
        }
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
			int healingAmount = damage / 30;
			p.statLife += healingAmount;
			p.HealEffect(healingAmount, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			Player p = Main.player[projectile.owner];
			int healingAmount = damage / 30;
			p.statLife += healingAmount;
			p.HealEffect(healingAmount, true);
		}
	}   
}