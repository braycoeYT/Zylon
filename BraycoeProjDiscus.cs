using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class BraycoeProjDiscus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braycoe's Discus");
        }
		public override void SetDefaults()
		{
			projectile.width = 39;
			projectile.height = 39;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1200;
			projectile.ignoreWater = true;
			projectile.light = 0.5f;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(5) == 0)
		    target.AddBuff(BuffID.Confused, 120, false);
		}
	}   
}