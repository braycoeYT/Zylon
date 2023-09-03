using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDSandBall : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sand Ball");
        }
		Player target;
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
			target = Main.player[(int)Projectile.ai[0]];
			Projectile.ai[0] = 0;
		}
		int rand = Main.rand.Next(-48, 49);
		float rand2 = Main.rand.NextFloat(-2, 2);
		bool fall;
        public override void AI() {
			if (!fall && Projectile.velocity.X > 0 && Projectile.Center.X > target.Center.X + rand + (target.velocity.X* 10)) {
				fall = true;
				Projectile.velocity = new Microsoft.Xna.Framework.Vector2(rand2, 6);
            }
			else if (!fall && Projectile.velocity.X <= 0 && Projectile.Center.X < target.Center.X + rand - (target.velocity.X* 10)) {
				fall = true;
				Projectile.velocity = new Microsoft.Xna.Framework.Vector2(rand2, 6);
            }
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}