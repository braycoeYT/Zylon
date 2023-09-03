using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Blowpipes
{
	public class Superstarshot_O : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Superstarshot");
        }
		bool word;
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.aiStyle = -1;
			Projectile.alpha = 255;
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer % 34 < 17) Projectile.alpha -= 15;
			else Projectile.alpha += 15;
            Projectile own = Main.projectile[(int)Projectile.ai[0]];
			Projectile.active = own.active;
			Projectile.Center = own.Center;
			Projectile.rotation = own.rotation;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}