using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Xenic
{
	public class XenicNucleus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenic Nucleus");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("XenicAcid"), 90, false);
		}
		public override void AI()
		{
			projectile.owner = mod.NPCType("XenicAcidpumper");
			projectile.velocity = Vector2.Normalize(projectile.Center - Main.npc[projectile.owner].Center) * (float)(-5f);
			if (projectile.Center == Main.npc[projectile.owner].Center)
			{
				if (Main.npc[projectile.owner].life + 250 > Main.npc[projectile.owner].lifeMax)
				Main.npc[projectile.owner].life += 250;
				else
				Main.npc[projectile.owner].life = Main.npc[projectile.owner].lifeMax;
				Main.npc[projectile.owner].HealEffect(250, true);
				projectile.timeLeft = 0;
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 193);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}