using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherJavelances
{
	public class Fleshleech : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleshleech");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(8) == 0)
			{
				Player p = Main.player[projectile.owner];
				int healingAmount = damage/30;
				p.statLife +=healingAmount;
				p.HealEffect(healingAmount, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(8) == 0)
			{
				Player p = Main.player[projectile.owner];
				int healingAmount = damage/30;
				p.statLife +=healingAmount;
				p.HealEffect(healingAmount, true);
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 235);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
	}   
}