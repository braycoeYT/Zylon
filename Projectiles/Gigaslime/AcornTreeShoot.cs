using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Gigaslime
{
	public class AcornTreeShoot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Acorn");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.timeLeft = 9999;
			Projectile.friendly = false;
			Projectile.hostile = true;
		}
		float trueRot = Main.rand.NextFloat(0, 2);
        public override void PostAI() {
            trueRot += 0.15f;
			Projectile.rotation = trueRot;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}