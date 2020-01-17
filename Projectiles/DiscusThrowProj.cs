using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class DiscusThrowProj : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("a Discus?");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 9999;
			projectile.melee = true;
			projectile.damage = 8;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Confused, 60, false);
		}
	}   
}