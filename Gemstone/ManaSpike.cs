using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Gemstone
{
	public class ManaSpike : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Gemstone");
        }
		public override void SetDefaults()
		{
			projectile.width = 21;
			projectile.height = 21;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player p = Main.player[projectile.owner];
			int healingAmount = (Main.rand.Next(1, 3));
			p.statMana += healingAmount;
			p.ManaEffect(healingAmount);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			Player p = Main.player[projectile.owner];
			int healingAmount = (Main.rand.Next(1, 3));
			p.statMana += healingAmount;
			p.ManaEffect(healingAmount);
		}
	}   
}