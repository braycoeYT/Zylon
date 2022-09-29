using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Yoyos
{
	public class AcornFriendlyMelee : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Acorn");
        }
		public override void SetDefaults() {
			Projectile.aiStyle = -1;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
		}
        public override void AI() {
            Projectile.rotation += 0.15f;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}