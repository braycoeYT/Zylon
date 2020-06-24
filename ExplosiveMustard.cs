using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class ExplosiveMustard : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Mustard");
        }
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 480;
			projectile.ignoreWater = true;
			projectile.light = 0f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Ichor, 600, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(10) == 0)
		    target.AddBuff(BuffID.Ichor, 600, false);
		}
	}   
}