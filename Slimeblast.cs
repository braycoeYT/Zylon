using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class Slimeblast : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimeblast");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0.5f;
			projectile.melee = true;
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void AI()
		{
			projectile.rotation += 0.02f;
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 80);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
	}   
}