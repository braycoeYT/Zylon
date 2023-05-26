using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Enemies
{
	public class WindElemental_ProtectDeco : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wind Elemental");
        }
        public override void SetDefaults() {
            Projectile.width = 70;
			Projectile.height = 66;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.penetrate = 9999;
        }
        Projectile main;
        public override void AI() {
			main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation += 0.15f;
			Projectile.scale = main.scale;
			Projectile.active = main.active;
			Projectile.Center = main.Center;
			Projectile.alpha = main.alpha;
        }
    }
}