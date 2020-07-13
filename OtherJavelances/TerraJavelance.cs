using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherJavelances
{
	public class TerraJavelance : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terra Javelance");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		int rand = Main.rand.Next(56, 151);
		public float Timer
		{
	        get => projectile.ai[1];
	        set => projectile.ai[1] = value;
        }
		public override void AI()
		{
			Timer++;
			if (Timer % rand == 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("TerraOrb"), 40, 0, Main.myPlayer);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(7) == 0)
			{
				Player p = Main.player[projectile.owner];
				int healingAmount = damage/30;
				p.statLife +=healingAmount;
				p.HealEffect(healingAmount, true);
			}
			ZylonPlayer zp = Main.player[projectile.owner].GetModPlayer<ZylonPlayer>();
			if (zp.bloodJavelance && Main.rand.NextFloat() < .06f && target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(7) == 0)
			{
				Player p = Main.player[projectile.owner];
				int healingAmount = damage/30;
				p.statLife +=healingAmount;
				p.HealEffect(healingAmount, true);
			}
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
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 273);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
	}   
}