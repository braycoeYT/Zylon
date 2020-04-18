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
			projectile.CloneDefaults(52);
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Confused, 60, false);
		}
	}   
}