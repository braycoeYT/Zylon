using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Meatyrang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meatyrang");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(52);
			projectile.width = 33;
			projectile.height = 33;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 999;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		    target.AddBuff(BuffID.Poisoned, 60, false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 60, false);
		}
		public override void AI()
		{
			projectile.timeLeft = 999;
		}
	}   
}