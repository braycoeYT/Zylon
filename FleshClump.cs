using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class FleshClump : ModProjectile
	{
		int damageFirst;
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flesh Clump");
        }
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.magic = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
			damageFirst = projectile.damage;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			projectile.damage -= (int)(damageFirst / 3);
		}
		public override void PostAI() {
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 125);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}