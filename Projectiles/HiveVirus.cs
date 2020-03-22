using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class HiveVirus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HIV(E) Virus");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 33;
			projectile.height = 33;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.timeLeft = 330;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .5f)
		    target.AddBuff(BuffID.Poisoned, 240, false);
		    if (Main.rand.NextFloat() < .1f)
		    target.AddBuff(BuffID.Venom, 180, false);
		}
	}   
}