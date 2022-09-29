using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class DesertSigil : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Sigil");
        }
		public override void SetDefaults() {
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}