using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class JungleSporeRanged : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jungle Spore");
		}

		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 9999;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			AIType = ProjectileID.Bullet;
		}
        public override void AI() {
            Projectile.velocity *= 0.95f;
			Lighting.AddLight(Projectile.Center, 0f, 0.5f, 0f);
			if (Projectile.velocity.X + Projectile.velocity.Y < 0.1f && Projectile.timeLeft > 240)
				Projectile.timeLeft = 240;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(5, 11), false);
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
    }
}