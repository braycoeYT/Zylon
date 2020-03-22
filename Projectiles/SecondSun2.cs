using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class SecondSun2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("the Second Sun");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.melee = true;
			projectile.damage = 15;
			//projectile.timeLeft = 300;
			projectile.ignoreWater = false;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(3) == 0)
		    target.AddBuff(BuffID.OnFire, 350, false);
		}
	}   
}