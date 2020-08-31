using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Zylon.Projectiles.ContagionexTools
{
	public class TocBacteriumBladeFake : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("False Bacterium Blade");
        }
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = -1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
			projectile.light = 0f;
			if (Main.expertMode)
			projectile.damage = 283;
			else
			projectile.damage = 217;
			projectile.alpha = 127;
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("ContagionToolsDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}