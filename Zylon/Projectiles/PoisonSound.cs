using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class PoisonSound : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Lure of a Poison Symphony");
        }
		public override void SetDefaults()
		{
			projectile.width = 13;
			projectile.height = 27;
			projectile.aiStyle = 21;
			projectile.friendly = true;
			projectile.penetrate = 25;
			projectile.magic = true;
			projectile.damage = 19;
			projectile.timeLeft = 240;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(7) == 0)
		    target.AddBuff(BuffID.Poisoned, 350, false);
		}
	}   
}