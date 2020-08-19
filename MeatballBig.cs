using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class MeatballBig : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Meatball");
        }
		public override void SetDefaults()
		{
			projectile.width = 78;
			projectile.height = 78;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 2500;
			projectile.ignoreWater = true;
			projectile.light = 0f;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(5) == 0)
		    target.AddBuff(70, 240, false);
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}