using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Dirtball
{
	public class DirtBallHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Ball");
        }
		public override void SetDefaults() {
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
		}
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}