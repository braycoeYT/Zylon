using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.ContagionexTools
{
	public class TocContagionOrbHostile : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bacterium Blade's Orb");
        }
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
			projectile.light = 0f;
			projectile.melee = true;
			if (Main.expertMode)
			projectile.damage = 258;
			else
			projectile.damage = 196;
		}
		public override void AI()
		{
			projectile.rotation += 0.02f;
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