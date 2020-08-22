using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Gemstone
{
	public class GemstoneOrbMedium : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Orb");
        }
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
			projectile.light = 0f;
			projectile.melee = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.justHit = false;
		}
		public override void AI()
		{
			projectile.rotation += 0.02f;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 58);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}