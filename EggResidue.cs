using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class EggResidue : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Egg Residue");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 1000;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.Venom, 150, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.Venom, 150, false);
		}
	}   
}