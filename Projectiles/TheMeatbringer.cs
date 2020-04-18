using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class TheMeatbringer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 7.5f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 240f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 11f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
				dust.noGravity = true;
				dust.scale = 0.1f;
			}
		}
	}
}