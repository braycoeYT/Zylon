using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Empress
{
	public class EmpressBleeders : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empress Bleeders");
        }
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player p = Main.player[projectile.owner];
			if (damage / 45 > 0 && target.type != NPCID.TargetDummy)
			{
				int healingAmount = damage / 45;
				if (healingAmount > 2)
					healingAmount = 2;
				p.statLife += healingAmount;
				p.HealEffect(healingAmount, true);
			}
			if (projectile.damage > 15)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("EmpressBleeders"), projectile.damage - 15, 3, Main.myPlayer);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			Player p = Main.player[projectile.owner];
			if (damage / 45 > 0)
			{
				int healingAmount = damage / 45;
				if (healingAmount > 2)
					healingAmount = 2;
				p.statLife += healingAmount;
				p.HealEffect(healingAmount, true);
			}
			if (projectile.damage > 15)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("EmpressBleeders"), projectile.damage - 15, 3, Main.myPlayer);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 90);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
	}   
}