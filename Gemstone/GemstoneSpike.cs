using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Gemstone
{
	public class GemstoneSpike : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Spike");
        }
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
	}   
}