using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Blowpipes
{
	public class Slimeball_Deco : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slimeball");
			Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults() {
            Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 9999;
			Projectile.tileCollide = false;
			Projectile.penetrate = 9999;
        }
        Projectile main;
        public override void AI() {
			main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation = main.rotation;
			Projectile.scale = Projectile.ai[1];
			if (Projectile.scale < 0.5f) Projectile.scale = 0.5f;
			Projectile.active = main.active;
			Projectile.Center = main.Center;
			Projectile.alpha = 0;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
        }
    }
}