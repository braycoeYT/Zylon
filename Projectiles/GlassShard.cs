using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles
{
	public class GlassShard : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glass Shard");
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.extraUpdates = 1;
		}
        public override void AI() {
            Projectile.velocity *= 1.01f;
			Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}