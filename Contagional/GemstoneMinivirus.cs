using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Contagional
{
	public class GemstoneMinivirus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Minivirus");
        }
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		    if (Main.rand.NextFloat() < .9f)
		    target.AddBuff(BuffID.Venom, 300, false);
			if (Main.rand.NextFloat() < .1f)
		    target.AddBuff(BuffID.Ichor, 180, false);
			if (Main.rand.NextFloat() < .1f)
		    target.AddBuff(39, 180, false);
			if (Main.rand.NextFloat() < .2f)
		    target.AddBuff(BuffID.Frostburn, 240, false);
			if (Main.rand.NextFloat() < .04f)
		    target.AddBuff(189, 240, false);
		}
	}   
}