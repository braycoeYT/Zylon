using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Accessories
{
	public class RootGuardProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Root Guard");
			Main.projFrames[Projectile.type] = 9;
        }
        public override void SetDefaults() {
            Projectile.width = 24;
			Projectile.height = 56;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
        }
		int Timer;
		bool init;
        Projectile main;
        public override void AI() {
			Timer++;
			Projectile.frame = Timer/3;
			if (Projectile.frame > 8) Projectile.frame = 8;
			if (Timer == 25) {
				//Spawn dust
            }
			if (Timer > 60) {
				//Begin despawn

				//Create second proj that when spawned, if player vel == 0 for three frames then just spawn at player feet, otherwise fall until tile collision and spawn
            }
        }
    }
}