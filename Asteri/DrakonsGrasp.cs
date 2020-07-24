using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Asteri
{
	public class DrakonsGrasp : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drakon's Grasp");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 80, false);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("DrakonsGhostGrasp"), projectile.damage / 2, 3, Main.myPlayer);
			ZylonPlayer zp = Main.player[projectile.owner].GetModPlayer<ZylonPlayer>();
			if (zp.bloodJavelance && Main.rand.NextFloat() < .06f && target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Venom, 80, false);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("DrakonsGhostGrasp"), projectile.damage / 2, 3, Main.myPlayer);
			ZylonPlayer zp = Main.player[projectile.owner].GetModPlayer<ZylonPlayer>();
			if (zp.bloodJavelance && Main.rand.NextFloat() < .06f) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 52);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
	}   
}