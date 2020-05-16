using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class BraycoeProjMineral : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braycoe's Mineral");
        }
		public override void SetDefaults()
		{
			projectile.width = 39;
			projectile.height = 39;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1800;
			projectile.ignoreWater = true;
			projectile.light = 0.5f;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Confused, 240, false);
			if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Frostburn, 350, false);
            if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Venom, 350, false);
		}
	}   
}