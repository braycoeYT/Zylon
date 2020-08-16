using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.OtherSeeds.PH.Crimson
{
	public class SproutedCrimtaneDeathweed : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Crimtane Deathweed");
			Main.projFrames[projectile.type] = 2;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		int Timer;
		int frameRand = Main.rand.Next(0, 2);
		public override void AI()
		{
			projectile.rotation = 0;
			Timer++;
			projectile.frameCounter = frameRand;
			projectile.frame = frameRand;
		}
	}   
}