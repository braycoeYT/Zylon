using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.ToolsofContagion
{
	public class FakeBacteriumBlade : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undying Flame of Infection");
			Main.projFrames[projectile.type] = 3;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 44;
			projectile.height = 44;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.alpha = 137;
		}
		int Timer;
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Sick"), 240, true);
			}
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(BuffID.CursedInferno, 240, true);
			}
		}
		public override void AI()
		{
			Timer++;
			if (Timer % 60 == 0)
			projectile.velocity.Y -= 1;
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 3)
				{
					projectile.frame = 0;
				}
			}
		}
	}   
}