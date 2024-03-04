using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles
{
	public class ExplosiveMarshmallow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Explosive Marshmallow");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Generic;
			AIType = 1;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.position - new Microsoft.Xna.Framework.Vector2(0, 30), new Microsoft.Xna.Framework.Vector2(0, 0), ProjectileID.DD2ExplosiveTrapT2Explosion, Projectile.damage, 2f, Main.myPlayer, BasicNetType: 2);
		}
	}   
}