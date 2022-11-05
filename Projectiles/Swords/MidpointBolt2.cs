using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Swords
{
	public class MidpointBolt2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Midpoint");
        }
		public override void SetDefaults() {
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 9999;
			Projectile.timeLeft = 60;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.light = 0.25f;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void AI() {
            for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkFairy);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}