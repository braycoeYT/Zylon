using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bosses.Dirtball
{
	public class LaserMineHostileFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Laser Mine");
        }
		public override void SetDefaults() {
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.width = 26;
			Projectile.height = 18;
			Projectile.aiStyle = 1;
		}
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Iron);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			Projectile.rotation = 0f;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), ModContent.ProjectileType<LaserMineHostile>(), Projectile.damage, 0f, BasicNetType: 2);
		}
	}   
}