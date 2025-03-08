using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class AssassinsArrow : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
		}
		int Timer;
		bool init;
        public override void AI() {
			Timer++;
			if (!init) {
				if (Main.player[Projectile.owner].magicQuiver) Projectile.extraUpdates = 1;
				init = true;

				if (Main.player[Projectile.owner].velocity.Length() < 0.01f) Projectile.damage = (int)(Projectile.damage*1.25f);
				Projectile.velocity *= 2f;
			}
			Projectile.velocity.X *= 1.03f;
			if (Projectile.velocity.Y < 0) Projectile.velocity.Y *= 1.03f;
			Projectile.velocity.Y += 0.02f*Timer;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}