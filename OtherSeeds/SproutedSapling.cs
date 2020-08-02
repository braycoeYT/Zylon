using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherSeeds
{
	public class SproutedSapling : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Sapling");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		int Timer;
		int frameRand = Main.rand.Next(0, 6);
		public override void AI()
		{
			projectile.rotation = 0;
			Timer++;
			projectile.frameCounter = frameRand;
			projectile.frame = frameRand;
		}
	}   
}