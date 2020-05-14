using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherSwords
{
	public class GemstoneTossblade : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Tossblade");
        }
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.damage = 10;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 255);
				dust.noGravity = false;
				dust.scale = 1f;
			}
		}
	}   
}