using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Enemies
{
	public class ElemSlimeSpike : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Slime Spike");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = -1;
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.frame = Main.rand.Next(2);
		}
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ElemDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}