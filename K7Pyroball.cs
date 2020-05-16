using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class K7Pyroball : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The lure of a Poison Symphony");
        }
		public override void SetDefaults()
		{
			projectile.width = 39;
			projectile.height = 39;
			projectile.aiStyle = 5;
			projectile.friendly = true;
			projectile.penetrate = 25;
			projectile.magic = true;
			projectile.damage = 19;
			projectile.timeLeft = 800;
			projectile.ignoreWater = false;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.OnFire, 350, false);
		    if (Main.rand.Next(7) == 0)
		    target.AddBuff(BuffID.CursedInferno, 350, false);
		    if (Main.rand.Next(12) == 0)
		    target.AddBuff(BuffID.Ichor, 350, false);
		}
	}   
}