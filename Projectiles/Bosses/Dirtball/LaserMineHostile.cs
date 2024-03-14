using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bosses.Dirtball
{
	public class LaserMineHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Laser Mine");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 18;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = Main.rand.Next(90, 241);
		}
        public override void AI() {
			if (Projectile.timeLeft < 60)
				if (Projectile.timeLeft % 10 < 5) Projectile.frame = 1;
				else Projectile.frame = 0;
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Iron);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -11), ModContent.ProjectileType<DirtballLaser>(), Projectile.damage, 0f, BasicNetType: 2);
		}
	}   
}