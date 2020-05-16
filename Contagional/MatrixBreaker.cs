using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Contagional
{
	public class MatrixBreaker : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Matrix Breaker");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 33;
			projectile.height = 33;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 7;
			projectile.timeLeft = 360;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .5f)
		    target.AddBuff(BuffID.Venom, 60, false);
			if (Main.rand.NextFloat() < .5f)
		    target.AddBuff(BuffID.Ichor, 60, false);
		}
	}   
}