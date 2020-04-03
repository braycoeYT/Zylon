using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class FireNote : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Note");
        }
		public override void SetDefaults()
		{
			projectile.width = 13;
			projectile.height = 27;
			projectile.aiStyle = 21;
			projectile.friendly = true;
			projectile.penetrate = 35;
			projectile.magic = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(BuffID.OnFire, 350, false);
		}
	}   
}